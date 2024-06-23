import axios from 'axios';

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

export default axiosConfig;
