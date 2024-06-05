using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Domain.DomainEvents;
public interface IDecisionHelper
{
    IReadOnlyList<RankedObjective> GetRanking(IReadOnlyList<ObjectiveEstimates> estimates, IReadOnlyList<DecisionHelperCriterion> criteria);
}
