namespace EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;

public sealed record UpdateDecisionHelperCriteriaRequest(IReadOnlyList<UpdateDecisionHelperCriterionRequest> Criteria)
{
}
