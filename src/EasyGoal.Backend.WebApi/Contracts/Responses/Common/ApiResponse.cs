namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public record ApiResponse<T> where T : BaseModelResponse
{
    public T? Data { get; protected init; }

    public ErrorResponse? Error { get; protected init; }

    public static ApiResponse<TResponse> FromResult<TResponse>(TResponse data) where TResponse : BaseModelResponse
    {
        return new ApiResponse<TResponse>
        {
            Data = data
        };
    }

    public static ApiResponse<TResponse> FromError<TResponse>(ErrorResponse error) where TResponse : BaseModelResponse
    {
        return new ApiResponse<TResponse>
        {
            Error = error
        };
    }
}
