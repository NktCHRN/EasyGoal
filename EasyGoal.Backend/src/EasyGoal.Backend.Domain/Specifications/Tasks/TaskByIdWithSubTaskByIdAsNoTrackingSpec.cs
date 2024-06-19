using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdWithSubTaskByIdAsNoTrackingSpec : SingleResultSpecification<Task>
{
    public TaskByIdWithSubTaskByIdAsNoTrackingSpec(Guid taskId, Guid subTaskId)
    {
        Query
            .AsNoTracking()
            .Include(t => t.SubTasks.Where(s => s.Id == subTaskId))
            .Where(t => t.Id == taskId);
    }
}
