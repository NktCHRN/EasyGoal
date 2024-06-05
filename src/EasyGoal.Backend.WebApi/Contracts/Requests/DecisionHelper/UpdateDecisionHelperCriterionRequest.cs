using EasyGoal.Backend.WebApi.Contracts.Enums;

namespace EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;

public sealed record UpdateDecisionHelperCriterionRequest(Guid? Id, string Name, double Weight, DecisionHelperCriterionType Type)
{
}
