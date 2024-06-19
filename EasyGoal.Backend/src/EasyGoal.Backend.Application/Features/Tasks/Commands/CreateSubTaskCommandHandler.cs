using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed class CreateSubTaskCommandHandler : IRequestHandler<CreateSubTaskCommand, SubTaskCreatedDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public CreateSubTaskCommandHandler(IRepository<Task> taskRepository, IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _taskRepository = taskRepository;
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task<SubTaskCreatedDto> Handle(CreateSubTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var task = await _taskRepository.FirstOrDefaultAsync(new TaskByIdWithSubTasksSpec(request.TaskId), cancellationToken)
            ?? throw new EntityNotFoundException($"Task with id {request.TaskId} was not found");
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalBySubGoalIdForOwnerValidationSpec(task.SubGoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {task.SubGoalId} was not found");

        goal.ValidateOwner(userId);

        var subTask = task.AddSubTask(request.Name);

        await _taskRepository.SaveChangesAsync(cancellationToken);

        return new SubTaskCreatedDto(subTask.Id);
    }
}
