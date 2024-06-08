namespace EasyGoal.Backend.WebApi.Contracts.Responses.Account;

public sealed record AccountRegisteredResponse(Guid Id, string Name, string Email);
