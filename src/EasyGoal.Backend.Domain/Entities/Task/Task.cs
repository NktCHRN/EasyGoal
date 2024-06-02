using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Enums;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class Task : BaseAuditableEntity
{
    public DateTimeOffset? StartTime { get; private set; }
    public DateTimeOffset? EndTime { get; private set; }
    public string? Notes { get; private set; }

    public Enums.TaskStatus Status { get; private set; }

    public Guid? TaskSeriesId { get; private set; }

    public SynchronisationStatus IsSynchonisedWithGoogle {  get; set; }
}
