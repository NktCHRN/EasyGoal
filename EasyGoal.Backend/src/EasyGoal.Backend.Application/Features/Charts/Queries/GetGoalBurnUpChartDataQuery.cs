using EasyGoal.Backend.Application.Features.Charts.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Charts.Queries;
public sealed record GetGoalBurnUpChartDataQuery(Guid GoalId, DateTimeOffset Start, DateTimeOffset End, string IanaCurrentTimeZone, int PointsCount) : IRequest<BurnUpChartDataDto>
{
}
