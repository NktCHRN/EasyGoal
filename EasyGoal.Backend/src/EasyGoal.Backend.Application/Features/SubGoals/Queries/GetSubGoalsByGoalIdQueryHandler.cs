using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Queries;
public sealed class GetSubGoalsByGoalIdQueryHandler : IRequestHandler<GetSubGoalsByGoalIdQuery, SubGoalsDto>
{
    private readonly IRepository<SubGoal> _subGoalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;

    public GetSubGoalsByGoalIdQueryHandler(IRepository<SubGoal> subGoalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _subGoalRepository = subGoalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<SubGoalsDto> Handle(GetSubGoalsByGoalIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var subGoals = await _subGoalRepository.ListAsync(new SubGoalsByGoalIdAsNoTrackingSpec(request.GoalId), cancellationToken);

        subGoals.FirstOrDefault()?.Goal.ValidateOwner(userId);

        return new SubGoalsDto(_mapper.Map<IReadOnlyList<SubGoalDto>>(subGoals));
    }
}
