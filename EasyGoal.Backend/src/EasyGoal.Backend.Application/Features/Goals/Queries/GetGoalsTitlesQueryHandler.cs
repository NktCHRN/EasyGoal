using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed class GetGoalsTitlesQueryHandler : IRequestHandler<GetGoalsTitlesQuery, GoalsTitlesDto>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;
    private readonly IMapper _mapper;

    public GetGoalsTitlesQueryHandler(ICurrentApplicationUser currentApplicationUser, IRepository<Goal> goalRepository, IMapper mapper)
    {
        _currentApplicationUser = currentApplicationUser;
        _goalRepository = goalRepository;
        _mapper = mapper;
    }

    public async Task<GoalsTitlesDto> Handle(GetGoalsTitlesQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goals = await _goalRepository.ListAsync(
            new GoalsTitlesSpec(userId),
            cancellationToken);

        var goalsDtos = _mapper.Map<IReadOnlyList<GoalTitleDto>>(goals);

        return new GoalsTitlesDto(goalsDtos);
    }
}
