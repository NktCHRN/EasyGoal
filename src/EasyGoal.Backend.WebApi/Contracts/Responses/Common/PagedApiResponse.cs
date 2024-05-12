namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public sealed record PagedApiResponse<T> : ApiResponse<PageResponse<T>>
{
    public PaginationParametersResponse? PaginationParameters { get; private init; }

    public static PagedApiResponse<TResponse> FromResult<TResponse>(PageResponse<TResponse> data, PaginationParametersResponse paginationParameters) where TResponse : BaseModelResponse
    {
        return new PagedApiResponse<TResponse>
        {
            Data = data,
            PaginationParameters = paginationParameters
        };
    }
}

public sealed record PageResponse<T>(IEnumerable<T> Items) : BaseModelResponse
{
}
