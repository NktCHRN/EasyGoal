using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class SubGoalByIdAsNoTrackingSpec : SingleResultSpecification<SubGoal>
{
    public SubGoalByIdAsNoTrackingSpec(Guid id)
    {
        Query
            .AsNoTracking()
            .Include(s => s.HistoricalRecords.OrderByDescending(h => h.Id).Take(1))
            .Where(s => s.Id == id);
    }
}
