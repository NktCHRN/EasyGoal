using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;

namespace EasyGoal.Backend.Domain.Specifications.DecisionHelper;
public class DecisionHelperCriteriaByUserIdSpec : Specification<DecisionHelperCriterion>
{
    public DecisionHelperCriteriaByUserIdSpec(Guid userId)
    {
        Query
            .Where(d => d.UserId == userId)
            .OrderBy(d => d.Order);
    }
}
