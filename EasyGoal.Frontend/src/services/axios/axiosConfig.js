import axios from 'axios';
import { getLogOutTokenHandler, getUpdateTokenHandler } from '../auth/tokenService';

export const axiosConfig = axios.create({
  baseURL: import.meta.env.VITE_PUBLIC_URL,
  headers: {
    'Content-Type': 'application/json', // change according header type accordingly
  },
});
axiosConfig.interceptors.request.use(
    (config) => {
      const accessToken = localStorage.getItem('accessToken'); // get stored access token
      if (accessToken) {
        config.headers.Authorization = `Bearer ${accessToken}`; // set in header
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
  axiosConfig.interceptors.response.use(
    (response) => {
      return response;
    },
    async (error) => {
      const originalRequest = error.config;
      if (error.response.status === 401 && !originalRequest._retry && !error.request.responseURL?.endsWith('login')) {
        originalRequest._retry = true;
        const accessToken = localStorage.getItem('accessToken');
        const refreshToken = localStorage.getItem('refreshToken');
        if (refreshToken) {
          try {
            const response = await axios.post(`${import.meta.env.VITE_PUBLIC_URL}/account/tokens/refreshToken`, {accessToken: accessToken, refreshToken: refreshToken});

            const newAccessToken = response.data.data.accessToken;
            const newRefreshToken = response.data.data.refreshToken;
            const updateToken = getUpdateTokenHandler();
            if (updateToken) {
              updateToken(newAccessToken, newRefreshToken);
            }

            originalRequest.headers.Authorization = `Bearer ${newAccessToken}`;
            return axios(originalRequest); //recall Api with new token
          } catch (error) {
            const logOut = getLogOutTokenHandler();
            logOut();
            // Handle token refresh failure
            // mostly logout the user and re-authenticate by login again
          }
        }
      }
      return Promise.reject(error);
    }
  );

export default axiosConfig;
