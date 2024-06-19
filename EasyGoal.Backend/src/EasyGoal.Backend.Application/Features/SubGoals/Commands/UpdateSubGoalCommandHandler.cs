using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Commands;
public sealed class UpdateSubGoalCommandHandler : IRequestHandler<UpdateSubGoalCommand>
{
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public UpdateSubGoalCommandHandler(IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task Handle(UpdateSubGoalCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalByIdWithSubGoalsSpec(request.GoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");

        goal.UpdateSubGoal(request.Id, request.Name, request.Deadline, userId);

        await _goalRepository.SaveChangesAsync(cancellationToken);
    }
}
