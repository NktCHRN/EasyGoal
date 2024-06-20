using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Domain.Abstractions.Utilities;
public interface IGanttChartDataProvider
{
    GanttChartData GetData(Goal goal, DateTimeOffset end, string ianaTimeZone);
}
