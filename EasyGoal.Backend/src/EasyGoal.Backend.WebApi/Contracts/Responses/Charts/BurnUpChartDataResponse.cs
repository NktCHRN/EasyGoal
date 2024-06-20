namespace EasyGoal.Backend.WebApi.Contracts.Responses.Charts;

public sealed record BurnUpChartDataResponse(IReadOnlyList<BurnUpChartItemResponse> Items)
{
}
