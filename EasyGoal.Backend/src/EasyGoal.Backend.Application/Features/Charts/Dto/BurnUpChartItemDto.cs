namespace EasyGoal.Backend.Application.Features.Charts.Dto;
public sealed record BurnUpChartItemDto
{
    public DateOnly Date { get; set; }
    public int DoneItems { get; set; }
    public int TotalItems { get; set; }
}
