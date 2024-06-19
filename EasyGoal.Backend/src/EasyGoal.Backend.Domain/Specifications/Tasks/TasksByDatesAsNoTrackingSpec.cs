using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TasksByDatesAsNoTrackingSpec : Specification<Task>
{
    public TasksByDatesAsNoTrackingSpec(DateTimeOffset start, DateTimeOffset end, Guid userId)
    {
        Query
            .AsNoTracking()
            .Where(t => t.StartTime != null && t.EndTime != null
                && ((t.StartTime >= start && t.StartTime < end) || (t.EndTime >= start && t.EndTime < end))
                && t.SubGoal.Goal.UserId == userId);
    }
}
