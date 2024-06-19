using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalByIdWithSubGoalsSpec : SingleResultSpecification<Goal>
{
    public GoalByIdWithSubGoalsSpec(Guid id)
    {
        Query
            .Include(g => g.SubGoals)
            .Where(g => g.Id == id);
    }
}
