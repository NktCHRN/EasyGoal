namespace EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
public sealed record DecisionHelperCriteriaDto
{
    public IReadOnlyList<DecisionHelperCriterionDto> Criteria { get; set; } = [];
}
