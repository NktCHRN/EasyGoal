using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdWithSubTasksSpec : SingleResultSpecification<Task>
{
    public TaskByIdWithSubTasksSpec(Guid id)
    {
        Query
            .Include(t => t.SubTasks)
            .Where(t => t.Id == id);
    }
}
