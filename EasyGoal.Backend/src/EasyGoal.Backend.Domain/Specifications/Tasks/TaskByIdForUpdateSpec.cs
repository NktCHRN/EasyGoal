using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TaskByIdForUpdateSpec : SingleResultSpecification<Task>
{
    public TaskByIdForUpdateSpec(Guid id)
    {
        Query.Where(t => t.Id == id);
    }
}
