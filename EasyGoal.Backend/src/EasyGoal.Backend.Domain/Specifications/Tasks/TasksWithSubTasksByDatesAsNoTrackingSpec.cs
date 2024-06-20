using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TasksWithSubTasksByDatesAsNoTrackingSpec : Specification<Task>
{
    public TasksWithSubTasksByDatesAsNoTrackingSpec(DateTimeOffset start, DateTimeOffset end, Guid userId)
    {
        Query
            .AsNoTracking()
            .Include(t => t.SubTasks)
            .Where(t => t.StartTime != null && t.EndTime != null
                && ((t.StartTime >= start && t.StartTime < end) || (t.EndTime >= start && t.EndTime < end))
                && t.SubGoal.Goal.UserId == userId);
    }
}
