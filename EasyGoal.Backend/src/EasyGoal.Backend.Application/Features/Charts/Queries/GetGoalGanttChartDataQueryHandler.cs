using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Abstractions.Utilities;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Utilities;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Charts.Queries;
public sealed class GetGoalGanttChartDataQueryHandler : IRequestHandler<GetGoalGanttChartDataQuery, GanttChartData>
{
    private readonly IHistoryRepository _historyRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IGanttChartDataProvider _ganttChartDataProvider;

    public GetGoalGanttChartDataQueryHandler(IHistoryRepository historyRepository, ICurrentApplicationUser currentApplicationUser, IGanttChartDataProvider ganttChartDataProvider)
    {
        _historyRepository = historyRepository;
        _currentApplicationUser = currentApplicationUser;
        _ganttChartDataProvider = ganttChartDataProvider;
    }

    public async Task<GanttChartData> Handle(GetGoalGanttChartDataQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _historyRepository.GetGoalWithSubGoalsStartDateEndDateAsync(request.GoalId)
            ?? throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");

        goal.ValidateOwner(userId);

        return _ganttChartDataProvider.GetData(goal, request.End, request.IanaCurrentTimeZone);
    }
}
