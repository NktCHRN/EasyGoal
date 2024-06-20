namespace EasyGoal.Backend.WebApi.Contracts.Responses.Charts;

public sealed record GanttChartDataResponse(IEnumerable<GanttChartLineResponse> Lines)
{
}
