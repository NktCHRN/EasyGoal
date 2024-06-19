using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public UpdateTaskStatusCommandHandler(IRepository<Task> taskRepository, IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _taskRepository = taskRepository;
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async System.Threading.Tasks.Task Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var task = await _taskRepository.FirstOrDefaultAsync(new TaskByIdForUpdateSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Task with id {request.Id} was not found");
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalBySubGoalIdForOwnerValidationSpec(task.SubGoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {task.SubGoalId} was not found");

        goal.ValidateOwner(userId);

        task.UpdateStatus(request.IsCompleted);

        await _taskRepository.SaveChangesAsync(cancellationToken);
    }
}
