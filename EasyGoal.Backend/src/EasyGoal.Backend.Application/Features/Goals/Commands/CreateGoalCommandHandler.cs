using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, GoalCreatedDto>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;

    public CreateGoalCommandHandler(ICurrentApplicationUser currentApplicationUser, IRepository<Goal> goalRepository)
    {
        _currentApplicationUser = currentApplicationUser;
        _goalRepository = goalRepository;
    }

    public async Task<GoalCreatedDto> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = Goal.Create(request.Name, request.Deadline, userId);

        await _goalRepository.AddAsync(goal, cancellationToken);

        return new GoalCreatedDto(goal.Id);
    }
}
