import {axiosConfig} from './axios/axiosConfig'

export const register = (user) =>
{
    return axiosConfig.post('account/register', user)
    .then(r => r.data.data)
    .catch(e => {throw e.response.data.error})
};

export const login = (user) =>
    {
        return axiosConfig.post('account/login', user)
        .then(r => r.data.data)
        .catch(e => {throw e.response.data.error})
    };
    