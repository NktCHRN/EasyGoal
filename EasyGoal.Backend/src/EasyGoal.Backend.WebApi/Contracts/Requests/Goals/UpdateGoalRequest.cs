namespace EasyGoal.Backend.WebApi.Contracts.Requests.Goals;

public sealed record UpdateGoalRequest(string Name, DateOnly Deadline, string? Description)
{
}
