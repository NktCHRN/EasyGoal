using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Domain.Abstractions.Utilities;
public interface IBurnUpChartDataProvider
{
    BurnUpChartData GetData(Goal goal, DateTimeOffset start, DateTimeOffset end, string ianaCurrentTimeZone, int pointsCount);
}
