using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdWithSubTasksAsNoTrackingSpec : SingleResultSpecification<Task>
{
    public TaskByIdWithSubTasksAsNoTrackingSpec(Guid taskId)
    {
        Query
            .AsNoTracking()
            .Include(t => t.SubTasks)
            .Where(t => t.Id == taskId);
    }
}
