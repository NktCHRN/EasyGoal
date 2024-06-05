namespace EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;

public sealed record ObjectivesRankingResponse(IReadOnlyList<RankedObjectiveResponse> Ranking)
{
}
