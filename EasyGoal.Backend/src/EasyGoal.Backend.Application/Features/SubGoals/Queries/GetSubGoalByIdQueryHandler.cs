using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Queries;
public sealed class GetSubGoalByIdQueryHandler : IRequestHandler<GetSubGoalByIdQuery, SubGoalDto>
{
    private readonly IRepository<SubGoal> _subGoalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;
    private readonly IRepository<Goal> _goalRepository;

    public GetSubGoalByIdQueryHandler(IRepository<SubGoal> subGoalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper, IRepository<Goal> goalRepository)
    {
        _subGoalRepository = subGoalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
        _goalRepository = goalRepository;
    }

    public async Task<SubGoalDto> Handle(GetSubGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var subGoal = await _subGoalRepository.FirstOrDefaultAsync(new SubGoalByIdAsNoTrackingSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {request.GoalId} was not found");
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalForOwnerValidationSpec(request.GoalId), cancellationToken);

        if (subGoal.GoalId != request.GoalId || goal is null)
        {
            throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");
        }

        goal.ValidateOwner(userId);

        return _mapper.Map<SubGoalDto>(subGoal);
    }
}
