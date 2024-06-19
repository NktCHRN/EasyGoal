using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TasksBySubGoalIdAsNoTrackingSpec : Specification<Task>
{
    public TasksBySubGoalIdAsNoTrackingSpec(Guid subGoalId)
    {
        Query
            .AsNoTracking()
            .Include(t => t.SubTasks)
            .Where(t => t.SubGoalId == subGoalId);
    }
}
