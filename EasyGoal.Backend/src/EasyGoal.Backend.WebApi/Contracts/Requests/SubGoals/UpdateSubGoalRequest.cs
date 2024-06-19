namespace EasyGoal.Backend.WebApi.Contracts.Requests.SubGoals;

public sealed record UpdateSubGoalRequest(string Name, DateOnly Deadline)
{
}
