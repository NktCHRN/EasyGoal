import {axiosConfig} from './axios/axiosConfig'

export const getUserGoals = (search, page, perPage) =>
{
    return axiosConfig.get('goals', {
        params:
        {
            searchText: search,
            page: page, 
            perPage: perPage
        }
    })
    .then(r => r.data.data)
    .catch(e => {throw e.response.data.error})
}
