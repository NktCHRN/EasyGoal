namespace EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;

public sealed record DecisionHelperCriteriaResponse(IReadOnlyList<DecisionHelperCriterionResponse> Criteria)
{
}
