using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalByIdForUpdateSpec : SingleResultSpecification<Goal>
{
    public GoalByIdForUpdateSpec(Guid id)
    {
        Query.Where(g => g.Id == id);
    }
}
