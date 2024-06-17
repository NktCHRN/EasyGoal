namespace EasyGoal.Backend.WebApi.Contracts.Responses.Goals;

public sealed record UserGoalsResponse(IEnumerable<GoalShortInfoResponse> Goals)
{
}
