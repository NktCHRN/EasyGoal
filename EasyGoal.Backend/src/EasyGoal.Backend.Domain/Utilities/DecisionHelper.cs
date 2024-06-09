using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Exceptions;
namespace EasyGoal.Backend.Domain.Utilities;
public sealed class DecisionHelper : IDecisionHelper
{
    private readonly IMCDAMethod _mcdaMethod;

    private const int MinEstimate = 1;
    private const int MaxEstimate = 10;

    public DecisionHelper(IMCDAMethod mcdaMethod)
    {
        _mcdaMethod = mcdaMethod;
    }

    public IReadOnlyList<RankedObjective> GetRanking(IReadOnlyList<ObjectiveEstimates> estimates, IReadOnlyList<DecisionHelperCriterion> criteria)
    {
        if (estimates.Count < 2)
        {
            throw new EntityValidationFailedException("At least two objectives are necessary for comparison");
        }

        if (!criteria.Any())
        {
            throw new EntityValidationFailedException("No criteria were specified");
        }

        if (estimates.Select(e => e.Estimates.Count).Distinct().Count() != 1
            || estimates[0].Estimates.Count != criteria.Count)
        {
            throw new EntityValidationFailedException("Estimates by all criteria must be specified for all objectives");
        }

        if (estimates.SelectMany(e => e.Estimates).Any(e => e < MinEstimate || e > MaxEstimate))
        {
            throw new EntityValidationFailedException($"Estimates must be in range [{MinEstimate};{MaxEstimate}]");
        }

        var (alternativesCount, criteriaCount) = (estimates.Count, criteria.Count);
        var alternativesMatrix = new int[alternativesCount, criteriaCount];
        for (var i = 0; i < alternativesCount; i++)
        {
            for (var j = 0; j < criteriaCount; j++)
            {
                alternativesMatrix[i, j] = estimates[i].Estimates[j];
            }
        }

        var weights = criteria
            .Select(c => c.Weight)
            .ToArray();

        var isMaximizedCriteria = criteria.Select(c => c.Type == Enums.DecisionHelperCriterionType.Ascending).ToArray();

        var ranking = _mcdaMethod.GetRanking(alternativesMatrix, weights, isMaximizedCriteria);

        return ranking.Select(r => new RankedObjective
        {
            Objective = estimates[r.Index].Objective,
            IsRecommended = r.IsCompromiseAlternative,
            Points = r.Points,
        }).ToList();
    }
}
