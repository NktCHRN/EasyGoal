namespace EasyGoal.Backend.Domain.Utilities;
public sealed record RankedObjective
{
    public bool IsRecommended { get; set; }
    public string Objective { get; set; } = string.Empty;
    public double Points { get; set; }
}
