using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalBySubGoalIdForOwnerValidationSpec : SingleResultSpecification<Goal>
{
    public GoalBySubGoalIdForOwnerValidationSpec(Guid subGoalId)
    {
        Query
            .AsNoTracking()
            .Where(g => g.SubGoals.Any(s => s.Id == subGoalId));
    }
}
