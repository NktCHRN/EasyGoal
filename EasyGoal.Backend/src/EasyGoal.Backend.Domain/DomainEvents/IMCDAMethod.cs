using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Domain.DomainEvents;
public interface IMCDAMethod
{
    IReadOnlyList<RankedAlternative> GetRanking(int[,] estimates, double[] weights, bool[] isMaximizedCriteria);
}
