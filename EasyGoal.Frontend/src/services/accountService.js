import {axiosConfig} from './axios/axiosConfig'

export const register = (user) =>
{
    return axiosConfig.post('account/register', user)
    .then(r => r.data)
    .catch(e => {
        console.error('Request register failed', error);
        throw e;
    })
};

export const login = (user) =>
    {
        return axiosConfig.post('account/login', user)
        .then(r => r.data)
        .catch(e => {
            console.error('Login request failed', error);
            throw e;
        })
    };
    