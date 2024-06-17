using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalByIdAsNoTrackingSpec : SingleResultSpecification<Goal>
{
    public GoalByIdAsNoTrackingSpec(Guid goalId)
    {
        Query
            .AsNoTracking()
            .Include(g => g.SubGoals)
                .ThenInclude(s => s.HistoricalRecords.OrderByDescending(h => h.Id).Take(1))
            .Include(g => g.FileAttachments)
            .Where(g => g.Id == goalId);
    }
}
