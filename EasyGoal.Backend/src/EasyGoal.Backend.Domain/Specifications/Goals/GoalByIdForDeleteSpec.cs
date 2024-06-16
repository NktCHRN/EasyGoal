using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalByIdForDeleteSpec : SingleResultSpecification<Goal>
{
    public GoalByIdForDeleteSpec(Guid id)
    {
        Query
            .Include(g => g.SubGoals)
                .ThenInclude(s => s.Tasks)
            .Where(g => g.Id == id);
    }
}
