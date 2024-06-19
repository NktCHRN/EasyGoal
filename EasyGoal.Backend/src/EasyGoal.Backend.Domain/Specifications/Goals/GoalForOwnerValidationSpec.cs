using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalForOwnerValidationSpec : SingleResultSpecification<Goal>
{
    public GoalForOwnerValidationSpec(Guid id)
    {
        Query
            .AsNoTracking()
            .Where(g => g.Id == id);
    }
}
