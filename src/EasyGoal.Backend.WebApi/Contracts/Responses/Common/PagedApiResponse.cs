namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public sealed record PagedApiResponse<T> : ApiResponse<IEnumerable<T>>
{
    public PaginationParametersResponse? PaginationParameters { get; init; }
}

public static class PagedApiResponse
{
    public static PagedApiResponse<TResponse> FromResult<TResponse>(IEnumerable<TResponse> data, PaginationParametersResponse paginationParameters)
    {
        return new PagedApiResponse<TResponse>
        {
            Data = data,
            PaginationParameters = paginationParameters
        };
    }
}
