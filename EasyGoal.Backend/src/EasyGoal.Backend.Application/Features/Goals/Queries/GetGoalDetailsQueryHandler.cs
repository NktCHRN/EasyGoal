using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed class GetGoalDetailsQueryHandler : IRequestHandler<GetGoalDetailsQuery, GoalDetailsDto>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;
    private readonly IMapper _mapper;

    public GetGoalDetailsQueryHandler(ICurrentApplicationUser currentApplicationUser, IRepository<Goal> goalRepository, IMapper mapper)
    {
        _currentApplicationUser = currentApplicationUser;
        _goalRepository = goalRepository;
        _mapper = mapper;
    }

    public async Task<GoalDetailsDto> Handle(GetGoalDetailsQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();

        var goal = await _goalRepository.FirstOrDefaultAsync(
            new GoalByIdAsNoTrackingSpec(userId),
            cancellationToken)
            ?? throw new EntityNotFoundException($"Goal with id {request.Id} was not found");
        goal.ValidateOwner(userId);

        var goalDto = _mapper.Map<GoalDetailsDto>(goal);

        return goalDto;
    }
}
