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

    public GetSubGoalByIdQueryHandler(IRepository<SubGoal> subGoalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _subGoalRepository = subGoalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<SubGoalDto> Handle(GetSubGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var subGoal = await _subGoalRepository.FirstOrDefaultAsync(new SubGoalByIdAsNoTrackingSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {request.GoalId} was not found");

        subGoal.Goal.ValidateOwner(userId);
        if (subGoal.GoalId != request.GoalId)
        {
            throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");
        }

        return _mapper.Map<SubGoalDto>(subGoal);
    }
}
