namespace EasyGoal.Backend.WebApi.Contracts.Responses.Account;

public sealed record LoginResponse(string AccessToken, string RefreshToken);
