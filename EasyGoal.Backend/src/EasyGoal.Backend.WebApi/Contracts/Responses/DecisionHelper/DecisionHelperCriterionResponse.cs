using EasyGoal.Backend.WebApi.Contracts.Enums;

namespace EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;

public sealed record DecisionHelperCriterionResponse(Guid Id, string Name, double Weight, DecisionHelperCriterionType Type)
{
}
