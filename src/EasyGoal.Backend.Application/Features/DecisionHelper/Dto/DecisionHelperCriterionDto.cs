using EasyGoal.Backend.Domain.Enums;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
public sealed record DecisionHelperCriterionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Weight { get; set; }
    public DecisionHelperCriterionType Type { get; set; }
}
