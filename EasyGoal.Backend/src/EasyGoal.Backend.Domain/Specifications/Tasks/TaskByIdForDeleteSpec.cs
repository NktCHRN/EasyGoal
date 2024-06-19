using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdForDeleteSpec : SingleResultSpecification<Task>
{
    public TaskByIdForDeleteSpec(Guid id)
    {
        Query.Where(t => t.Id == id);
    }
}
