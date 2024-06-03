namespace EasyGoal.Backend.WebApi.Contracts.Requests.Account;

public sealed record RegisterAccountRequest(string Email, string Name, string Password);
