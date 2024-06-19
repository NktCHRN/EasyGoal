using Ardalis.Specification;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Domain.Specifications.Tasks;
public sealed class TasksBySubGoalIdSpec : Specification<Task>
{
    public TasksBySubGoalIdSpec(Guid subGoalId)
    {
        Query.Where(t => t.SubGoalId == subGoalId);
    }
}
