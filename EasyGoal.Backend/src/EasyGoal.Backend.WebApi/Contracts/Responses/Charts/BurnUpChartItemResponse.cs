namespace EasyGoal.Backend.WebApi.Contracts.Responses.Charts;

public sealed record BurnUpChartItemResponse
{
    public DateOnly Date { get; set; }
    public int DoneItems { get; set; }
    public int TotalItems { get; set; }
}
