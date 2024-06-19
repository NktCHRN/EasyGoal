using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.History;

namespace EasyGoal.Backend.Domain.Specifications.History;
public sealed class NewestHistoricalRecordBySubGoalIdSpec : SingleResultSpecification<HistoricalRecord>
{
    public NewestHistoricalRecordBySubGoalIdSpec(Guid subGoalId)
    {
        Query
            .Where(h => h.SubGoalId == subGoalId)
            .OrderByDescending(h => h.Date)
            .Take(1);
    }
}
