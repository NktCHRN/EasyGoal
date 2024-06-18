namespace EasyGoal.Backend.WebApi.Contracts.Requests.SubGoals;

public sealed record CreateSubGoalRequest(string Name, DateOnly Deadline)
{
}
