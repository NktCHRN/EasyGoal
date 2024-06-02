namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public record ApiResponse<T>
{
    public T? Data { get; init; }

    public ErrorResponse? Error { get; init; }
}

public static class ApiResponse
{
    public static ApiResponse<TResponse> FromResult<TResponse>(TResponse data)
    {
        return new ApiResponse<TResponse>
        {
            Data = data
        };
    }

    public static ApiResponse<object> FromError(ErrorResponse error)
    {
        return new ApiResponse<object>
        {
            Error = error
        };
    }
}
