namespace EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
public sealed record RankedObjectiveDto
{
    public bool IsRecommended { get; set; }
    public string Objective {  get; set; } = string.Empty;
    public double Points { get; set; }
}
