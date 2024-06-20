using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalsTitlesSpec : Specification<Goal>
{
    public GoalsTitlesSpec(Guid userId)
    {
        Query
            .AsNoTracking()
            .Where(g => g.UserId == userId)
            .OrderByDescending(g => g.Id);
    }
}
