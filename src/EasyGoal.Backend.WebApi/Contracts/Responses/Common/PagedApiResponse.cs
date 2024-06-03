namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public sealed record PagedApiResponse<T>(IEnumerable<T>? Data, PaginationParametersResponse? PaginationParameters, ErrorResponse? Error) : ApiResponse<IEnumerable<T>>(Data, Error)
{
}

public static class PagedApiResponse
{
    public static PagedApiResponse<TResponse> FromResult<TResponse>(IEnumerable<TResponse> data, PaginationParametersResponse paginationParameters)
    {
        return new PagedApiResponse<TResponse>(data, paginationParameters, null);
    }
}
