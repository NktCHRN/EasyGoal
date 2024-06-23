using EasyGoal.Backend.Domain.Abstractions.Utilities;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;
using NodaTime;

namespace EasyGoal.Backend.Domain.Utilities;
public sealed class BurnUpChartDataProvider : IBurnUpChartDataProvider
{
    public BurnUpChartData GetData(Goal goal, DateTimeOffset start, DateTimeOffset end, string ianaCurrentTimeZone, int pointsCount)
    {
        if (pointsCount < 2)
        {
            throw new EntityValidationFailedException($"Chart cannot be built for less than 2 points.");
        }
        if (end < start)
        {
            throw new EntityValidationFailedException("Start date must be earlier than end date");
        }

        var timeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(ianaCurrentTimeZone)
            ?? throw new EntityValidationFailedException($"Your time zone {ianaCurrentTimeZone} was not found");
        
        var dates = GetDates(goal, timeZone, start, end, pointsCount);

        var historicalRecords = goal
            .SubGoals
            .Select(s => new
            {
                s.Id,
                HistoricalRecords = s.HistoricalRecords
                .Select(h => (h, Instant.FromDateTimeOffset(h.DateTime).InZone(timeZone).Date.ToDateOnly()))
                .OrderBy(h => h.Item1.DateTime)
                .ToList()
            })
            .ToDictionary(k => k.Id, v => v.HistoricalRecords);

        var items = new BurnUpChartItem[dates.Count];

        for (var i = 0; i < dates.Count; i++)
        {
            items[i] = GetChartItemByDate(goal, historicalRecords, timeZone, dates[i]);
        }

        return new BurnUpChartData(items);
    }

    private static List<DateOnly> GetDates(Goal goal, DateTimeZone timeZone, DateTimeOffset start, DateTimeOffset end, int pointsCount)
    {
        var startDate = goal.CreatedAt > start
            ? Instant.FromDateTimeOffset(goal.CreatedAt).InZone(timeZone).Date.ToDateOnly()
            : DateOnly.FromDateTime(start.DateTime);
        var endDate = goal.EndDate.HasValue && goal.EndDate.Value < end
            ? Instant.FromDateTimeOffset(goal.EndDate.Value).InZone(timeZone).Date.ToDateOnly()
            : DateOnly.FromDateTime(end.DateTime);
        if (endDate < startDate)
        {
            endDate = startDate;
        }
        if (pointsCount > endDate.DayNumber - startDate.DayNumber + 1)
        {
            pointsCount = endDate.DayNumber - startDate.DayNumber + 1;
        }

        var dates = new List<DateOnly>();

        var step = pointsCount != 1 ? (endDate.DayNumber - startDate.DayNumber) / (double)(pointsCount - 1) : 0;

        for (var i = 0; i < pointsCount; i++)
        {
            dates.Add(startDate.AddDays((int)Math.Round(i * step)));
        }

        return dates;
    }

    private static BurnUpChartItem GetChartItemByDate(Goal goal, IReadOnlyDictionary<Guid, List<(HistoricalRecord Record, DateOnly Date)>> historicalRecords, DateTimeZone timeZone, DateOnly date)
    {
        var item = new BurnUpChartItem
        {
            Date = date
        };

        foreach (var subGoal in goal.SubGoals)
        {
            var historicalRecord = historicalRecords[subGoal.Id]
                .LastOrDefault(h => h.Date <= date);

            item.DoneItems += historicalRecord.Record?.CurrentDoneItems ?? 0;
            item.TotalItems += historicalRecord.Record?.CurrentTotalItems ?? 0;
        }

        return item;
    }
}
