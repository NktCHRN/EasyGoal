using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalByIdForAddingSubGoalSpec : SingleResultSpecification<Goal>
{
    public GoalByIdForAddingSubGoalSpec(Guid id)
    {
        Query.Where(g => g.Id == id);
    }
}
