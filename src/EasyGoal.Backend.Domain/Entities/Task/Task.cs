using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Enums;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class Task : BaseAuditableEntity
{
    public bool IsCompleted { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset? StartTime { get; private set; }
    public DateTimeOffset? EndTime { get; private set; }
    public string? Notes { get; private set; }

    public Enums.TaskStatus Status { get; private set; }
    public SynchronisationStatus? IsSynchonisedWithGoogle { get; set; }

    //public Guid? TaskSeriesId { get; private set; }
    //public TaskSeries.TaskSeries? TaskSeries { get; private set; }
    public IReadOnlyList<SubTask> SubTasks => _subTasks.AsReadOnly();
    private readonly List<SubTask> _subTasks = [];
}
