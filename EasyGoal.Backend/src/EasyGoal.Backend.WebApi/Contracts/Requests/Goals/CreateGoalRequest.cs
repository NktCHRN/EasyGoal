namespace EasyGoal.Backend.WebApi.Contracts.Requests.Goals;

public sealed record CreateGoalRequest(string Name, DateOnly Deadline)
{
}
