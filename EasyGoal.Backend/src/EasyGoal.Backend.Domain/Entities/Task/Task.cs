using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Enums;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class Task : BaseAuditableEntity
{
    public bool IsCompleted { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset? StartTime { get; private set; }
    public DateTimeOffset? EndTime { get; private set; }
    public string? Notes { get; private set; }

    public SynchronisationStatus? GoogleSynchronisationStatus { get; set; }

    public IReadOnlyList<SubTask> SubTasks => _subTasks.AsReadOnly();
    private readonly List<SubTask> _subTasks = [];
    public Guid SubGoalId { get; private set; }

    private Task() { }

    public static Task Create(string name, DateTimeOffset? startTime, DateTimeOffset? endTime, Guid subGoalId)
    {
        var task = new Task
        {
            Name = name,
            StartTime = startTime,
            EndTime = endTime,
            SubGoalId = subGoalId
        };

        task.Validate();

        task.AddDomainEvent(new TaskCreatedEvent(task.Id, task.SubGoalId));

        return task;
    }

    public new void Delete()
    {
        base.Delete();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Task name must not be empty");
        }

        if (!StartTime.HasValue ^ !EndTime.HasValue)
        {
            throw new EntityValidationFailedException("Either both end time and start time should be set or none of them");
        }

        if (StartTime.HasValue && EndTime.HasValue && EndTime < StartTime)
        {
            throw new EntityValidationFailedException("End time cannot be earlier than start time");
        }
    }
}
