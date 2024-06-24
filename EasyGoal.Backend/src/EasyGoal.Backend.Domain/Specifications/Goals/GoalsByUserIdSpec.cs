using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalsByUserIdSpec : Specification<Goal>
{
    public GoalsByUserIdSpec(Guid userId) 
    {
        Query
            .AsNoTracking()
            .Where(g => g.UserId == userId);
    }
}
