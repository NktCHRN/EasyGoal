using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.SubGoals.EventHandlers;
public sealed class SubGoalDeletedEventHandler : INotificationHandler<SubGoalDeletedEvent>
{
    private readonly IRepository<Task> _taskRepository;

    public SubGoalDeletedEventHandler(IRepository<Task> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(SubGoalDeletedEvent notification, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.ListAsync(new TasksBySubGoalIdSpec(notification.SubGoalId), cancellationToken);

        foreach (var task in tasks)
        {
            task.Delete();
        }
    }
}
