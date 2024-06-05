namespace EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;

public sealed record GetObjectivesRankingRequest(IReadOnlyList<ObjectiveEstimates> Estimates)
{
}
