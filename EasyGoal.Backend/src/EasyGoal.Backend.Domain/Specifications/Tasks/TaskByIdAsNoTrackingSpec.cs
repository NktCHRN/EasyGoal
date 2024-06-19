using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdAsNoTrackingSpec : Specification<Task>
{
    public TaskByIdAsNoTrackingSpec(Guid id)
    {
        Query
            .AsNoTracking()
            .Include(t => t.SubTasks)
            .Where(t => t.Id == id);
    }
}
