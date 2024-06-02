using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.TaskSeries;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class SubGoal : BaseAuditableEntity
{
    public TaskCompletionType TaskCompletionType { get; private set; }
}
