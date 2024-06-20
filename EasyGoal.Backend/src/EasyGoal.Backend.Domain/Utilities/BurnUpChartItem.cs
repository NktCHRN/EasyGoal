namespace EasyGoal.Backend.Domain.Utilities;
public sealed record BurnUpChartItem
{
    public DateOnly Date { get; set; }
    public int DoneItems { get; set; }
    public int TotalItems { get; set; }
}
