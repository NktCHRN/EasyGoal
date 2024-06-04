namespace EasyGoal.Backend.WebApi.Contracts.Requests.Account;

public sealed record RefreshTokensRequest(string AccessToken, string RefreshToken);
