namespace EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
public sealed record ObjectiveEstimatesDto
{
    public string Objective { get; set; } = string.Empty;
    public IReadOnlyList<int> Estimates { get; set; } = [];
}
