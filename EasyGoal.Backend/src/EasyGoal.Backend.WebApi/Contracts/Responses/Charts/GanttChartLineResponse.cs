namespace EasyGoal.Backend.WebApi.Contracts.Responses.Charts;

public sealed record GanttChartLineResponse(string Name, DateOnly Start, DateOnly End)
{
}
