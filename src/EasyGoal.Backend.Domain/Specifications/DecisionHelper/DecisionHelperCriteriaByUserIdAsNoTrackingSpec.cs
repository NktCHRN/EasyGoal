using Ardalis.Specification;

namespace EasyGoal.Backend.Domain.Specifications.DecisionHelper;
public sealed class DecisionHelperCriteriaByUserIdAsNoTrackingSpec : DecisionHelperCriteriaByUserIdSpec
{
    public DecisionHelperCriteriaByUserIdAsNoTrackingSpec(Guid userId) : base(userId)
    {
        Query.AsNoTracking();
    }
}
