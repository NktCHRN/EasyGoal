using EasyGoal.Backend.Domain.Abstractions.Utilities;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using NodaTime;

namespace EasyGoal.Backend.Domain.Utilities;
public sealed class GanttChartDataProvider : IGanttChartDataProvider
{
    public GanttChartData GetData(Goal goal, DateTimeOffset end, string ianaTimeZone)
    {
        var timeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(ianaTimeZone)
            ?? throw new EntityValidationFailedException($"Your time zone {ianaTimeZone} was not found");

        var lines = new List<GanttChartLine>();
        foreach (var subGoal in goal.SubGoals)
        {
            var subGoalStart = subGoal.HistoricalRecords.Min(h => h.DateTime);
            var latestRecord = subGoal.HistoricalRecords.MaxBy(h => h.DateTime)!;
            var subGoalEnd = latestRecord.IsDone ? latestRecord.DateTime : end;

            lines.Add(new GanttChartLine(
                subGoal.Name, 
                Instant.FromDateTimeOffset(subGoalStart).InZone(timeZone).Date.ToDateOnly(),
                Instant.FromDateTimeOffset(subGoalEnd).InZone(timeZone).Date.ToDateOnly()));
        }

        return new GanttChartData(lines);
    }
}
