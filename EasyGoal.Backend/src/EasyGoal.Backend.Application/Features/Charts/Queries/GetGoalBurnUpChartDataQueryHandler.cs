using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Charts.Dto;
using EasyGoal.Backend.Domain.Abstractions.Utilities;
using EasyGoal.Backend.Domain.Abstractions;
using MediatR;
using AutoMapper;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Application.Features.Charts.Queries;
public sealed class GetGoalBurnUpChartDataQueryHandler : IRequestHandler<GetGoalBurnUpChartDataQuery, BurnUpChartDataDto>
{
    private readonly IHistoryRepository _historyRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IBurnUpChartDataProvider _burnUpChartProvider;
    private readonly IMapper _mapper;

    public GetGoalBurnUpChartDataQueryHandler(IHistoryRepository historyRepository, ICurrentApplicationUser currentApplicationUser, IBurnUpChartDataProvider burnUpChartProvider, IMapper mapper)
    {
        _historyRepository = historyRepository;
        _currentApplicationUser = currentApplicationUser;
        _burnUpChartProvider = burnUpChartProvider;
        _mapper = mapper;
    }

    public async Task<BurnUpChartDataDto> Handle(GetGoalBurnUpChartDataQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _historyRepository.GetGoalWithSubGoalsAndHistoricalRecordsByDatesAsync(request.GoalId, request.Start, request.End)
            ?? throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");
        goal.ValidateOwner(userId);

        var data = _burnUpChartProvider.GetData(goal, request.Start, request.End, request.IanaCurrentTimeZone, request.PointsCount);

        return _mapper.Map<BurnUpChartDataDto>(data);
    }
}
