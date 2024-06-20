using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Entities.History;
public class HistoricalRecord : BaseEntity
{
    public DateTimeOffset DateTime { get; private set; }
    public int CurrentDoneItems { get; private set; }
    public int CurrentTotalItems { get; private set; }

    public Guid SubGoalId { get; private set; }
    public SubGoal SubGoal { get; private set; } = null!;

    public bool IsDone => CurrentDoneItems == CurrentTotalItems;

    private HistoricalRecord() { }

    public static HistoricalRecord Create(DateTimeOffset dateTime, Guid subGoalId)
    {
        return new HistoricalRecord
        {
            DateTime = dateTime,
            SubGoalId = subGoalId,
        };
    }

    public HistoricalRecord AddItem(DateTimeOffset dateTime)
    {
        var record = CreateFromCurrent(dateTime);
        record.CurrentTotalItems++;

        return record;
    }

    public HistoricalRecord DoItem(DateTimeOffset dateTime)
    {
        var record = CreateFromCurrent(dateTime);
        record.CurrentDoneItems++;

        return record;
    }

    public HistoricalRecord UndoItem(DateTimeOffset dateTime)
    {
        var record = CreateFromCurrent(dateTime);
        record.CurrentDoneItems--;

        return record;
    }

    public HistoricalRecord RemoveItem(DateTimeOffset dateTime, bool isDone)
    {
        var record = CreateFromCurrent(dateTime);

        if (isDone)
        {
            record.CurrentDoneItems--;
        }

        record.CurrentTotalItems--;

        return record;
    }

    private HistoricalRecord CreateFromCurrent(DateTimeOffset dateTime)
    {
        return new HistoricalRecord
        {
            DateTime = dateTime,
            SubGoalId = SubGoalId,
            CurrentDoneItems = CurrentDoneItems,
            CurrentTotalItems = CurrentTotalItems,
        };
    }
}
