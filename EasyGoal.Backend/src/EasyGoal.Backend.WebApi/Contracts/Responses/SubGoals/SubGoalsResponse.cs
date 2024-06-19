namespace EasyGoal.Backend.WebApi.Contracts.Responses.SubGoals;

public sealed record SubGoalsResponse(IReadOnlyList<SubGoalResponse> SubGoals)
{
}
