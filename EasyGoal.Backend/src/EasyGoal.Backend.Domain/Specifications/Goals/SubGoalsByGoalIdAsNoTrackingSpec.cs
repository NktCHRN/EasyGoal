using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class SubGoalsByGoalIdAsNoTrackingSpec : Specification<SubGoal>
{
    public SubGoalsByGoalIdAsNoTrackingSpec(Guid goalId)
    {
        Query
            .AsNoTracking()
            .Include(s => s.Goal)
            .Include(s => s.HistoricalRecords.OrderByDescending(h => h.Id).Take(1))
            .Where(s => s.GoalId == goalId);
    }
}
