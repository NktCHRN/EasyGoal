namespace EasyGoal.Backend.Domain.Utilities;
public sealed record RankedAlternative
{
    public int Index { get; set; }
    public bool IsCompromiseAlternative { get; set; }
    public double Points { get; set; }
}
