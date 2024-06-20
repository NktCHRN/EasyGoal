namespace EasyGoal.Backend.WebApi.Contracts.Responses.Goals;

public sealed record GoalsTitlesResponse(IEnumerable<GoalTitleResponse> Goals)
{
}
