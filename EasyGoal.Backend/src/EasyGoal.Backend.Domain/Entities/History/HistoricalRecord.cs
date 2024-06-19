using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Entities.History;
public class HistoricalRecord : BaseEntity
{
    public DateOnly Date { get; private set; }
    public int CurrentDoneItems { get; private set; }
    public int CurrentTotalItems { get; private set; }

    public Guid SubGoalId { get; private set; }
    public SubGoal SubGoal { get; private set; } = null!;

    private static readonly DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.UtcNow);

    private HistoricalRecord() { }

    public static HistoricalRecord Create(Guid subGoalId)
    {
        return new HistoricalRecord
        {
            Date = CurrentDate,
            SubGoalId = subGoalId,
        };
    }

    public HistoricalRecord CreateOrUpdateByCurrentDate()
    {
        if (Date == CurrentDate)
        {
            return this;
        }

        return Create(SubGoalId);
    }

    public void AddItem()
    {
        CurrentTotalItems++;
    }

    public void DoItem()
    {
        CurrentDoneItems++;
    }

    public void UndoItem()
    {
        CurrentDoneItems--;
    }

    public void RemoveItem(bool isDone)
    {
        if (isDone)
        {
            CurrentDoneItems--;
        }

        CurrentTotalItems--;
    }
}
