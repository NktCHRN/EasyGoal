namespace EasyGoal.Backend.WebApi.Contracts.Requests.Account;

public sealed record LoginRequest(string Email, string Password);
