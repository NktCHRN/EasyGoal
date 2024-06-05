namespace EasyGoal.Backend.Domain.Utilities;
public sealed record ObjectiveEstimates
{
    public string Objective { get; set; } = string.Empty;
    public IReadOnlyList<int> Estimates { get; set; } = [];
}
