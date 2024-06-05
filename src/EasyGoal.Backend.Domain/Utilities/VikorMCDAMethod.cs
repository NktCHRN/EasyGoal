using EasyGoal.Backend.Domain.DomainEvents;

namespace EasyGoal.Backend.Domain.Utilities;
public sealed class VikorMCDAMethod : IMCDAMethod
{
    private const double V = 0.75;

    public IReadOnlyList<RankedAlternative> GetRanking(int[,] estimates, double[] weights)
    {
        var normalizedEstimates = GetNormalizedEstimates(estimates);

        var weightedEstimates = GetWeightedEstimates(normalizedEstimates, weights);

        var s = GetS(weightedEstimates);
        var r = GetR(weightedEstimates);
        var q = GetQ(s, r);

        return GetSortedRanking(s, r, q);
    }

    private static double[,] GetNormalizedEstimates(int[,] estimates)
    {
        var minEstimates = GetMinEstimatesByCriteria(estimates);
        var maxEstimates = GetMaxEstimatesByCriteria(estimates);

        var normalizedEstimates = new double[estimates.GetLength(0), estimates.GetLength(1)];

        for (var i = 0; i < normalizedEstimates.GetLength(0); i++)
        {
            for (var j = 0; j < normalizedEstimates.GetLength(1); j++)
            {
                var delta = maxEstimates[j] - minEstimates[j];
                if (delta == 0)     // In this case we will have 0 / 0 everywhere. Let's change it to 1 / 0.
                {
                    delta = 1;
                }

                normalizedEstimates[i, j] = (maxEstimates[j] - estimates[i, j]) / (double)delta;
            }
        }

        return normalizedEstimates;
    }

    private static int[] GetMinEstimatesByCriteria(int[,] estimates)
    {
        var criteriaCount = estimates.GetLength(1);
        var minEstimates = new int[criteriaCount];

        for (var i = 0; i < criteriaCount; i++)
        {
            minEstimates[i] = int.MaxValue;

            for (var j = 0; j < estimates.GetLength(0); j++)
            {
                if (estimates[j, i] < minEstimates[i])
                {
                    minEstimates[i] = estimates[j, i];
                }
            }
        }

        return minEstimates;
    }

    private static int[] GetMaxEstimatesByCriteria(int[,] estimates)
    {
        var criteriaCount = estimates.GetLength(1);
        var maxEstimates = new int[criteriaCount];

        for (var i = 0; i < criteriaCount; i++)
        {
            maxEstimates[i] = int.MinValue;

            for (var j = 0; j < estimates.GetLength(0); j++)
            {
                if (estimates[j, i] > maxEstimates[i])
                {
                    maxEstimates[i] = estimates[j, i];
                }
            }
        }

        return maxEstimates;
    }

    private static double[,] GetWeightedEstimates(double[,] normalizedEstimates, double[] weights)
    {
        var weightedEstimates = new double[normalizedEstimates.GetLength(0), normalizedEstimates.GetLength(1)];

        for (var i = 0; i < weightedEstimates.GetLength(0); i++)
        {
            for (var j = 0; j < weightedEstimates.GetLength(1); j++)
            {
                weightedEstimates[i, j] = normalizedEstimates[i, j] * weights[j];
            }
        }

        return weightedEstimates;
    }

    private static double[] GetS(double[,] weightedEstimates)
    {
        var s = new double[weightedEstimates.GetLength(0)];

        for (var i = 0; i < weightedEstimates.GetLength(0); i++)
        {
            for (var j = 0; j < weightedEstimates.GetLength(1); j++)
            {
                s[i] += weightedEstimates[i, j];
            }
        }

        return s;
    }

    private static double[] GetR(double[,] weightedEstimates)
    {
        var r = new double[weightedEstimates.GetLength(0)];

        for (var i = 0; i < weightedEstimates.GetLength(0); i++)
        {
            for (var j = 0; j < weightedEstimates.GetLength(1); j++)
            {
                if (weightedEstimates[i, j] > r[i])
                {
                    r[i] = weightedEstimates[i, j];
                }
            }
        }

        return r;
    }

    private static double[] GetQ(double[] s, double[] r)
    {
        var (sMax, sMin) = (s.Max(), s.Min());
        var (rMax, rMin) = (r.Max(), r.Min());

        var q = new double[s.Length];
        for (var i = 0; i < q.Length; i++)
        {
            q[i] = V * (s[i] - sMin) / (sMax - sMin) + (1 - V) * (r[i] - rMin) / (rMax - rMin);
        }

        return q;
    }

    private static List<RankedAlternative> GetSortedRanking(double[] s, double[] r, double[] q)
    {
        var sortedQ = q
            .Select((q, i) => new RankedAlternative { Index = i, Points = q })
            .OrderBy(q => q.Points)
            .ToList();

        var alternativesCount = q.Length;
        var bestAlternative = sortedQ[0];
        var preBestAlternative = sortedQ[1];

        bestAlternative.IsCompromiseAlternative = true;

        var currentQIndex = 1;
        while (currentQIndex < sortedQ.Count && !IsC1Satisfied(bestAlternative.Points, sortedQ[currentQIndex].Points, alternativesCount))
        {
            sortedQ[currentQIndex].IsCompromiseAlternative = true;
            currentQIndex++;
        }
        if (!IsC2Satisfied(bestAlternative.Index, s, r))
        {
            preBestAlternative.IsCompromiseAlternative = true;
        }

        return sortedQ;
    }

    private static bool IsC1Satisfied(double bestAlternativeQ, double preBestAlternativeQ, int alternativesCount)
    {
        var dq = 1 / (double)(alternativesCount - 1);

        return preBestAlternativeQ - bestAlternativeQ >= dq;
    }

    private static bool IsC2Satisfied(int bestAlternativeIndex, double[] s, double[] r)
    {
        return s[bestAlternativeIndex] == s.Min() || r[bestAlternativeIndex] == r.Min();
    }
}
