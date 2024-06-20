using EasyGoal.Backend.Domain.Utilities;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Charts.Queries;
public sealed record GetGoalGanttChartDataQuery(Guid GoalId, DateTimeOffset Start, DateTimeOffset End, string IanaCurrentTimeZone) : IRequest<GanttChartData>
{
}
