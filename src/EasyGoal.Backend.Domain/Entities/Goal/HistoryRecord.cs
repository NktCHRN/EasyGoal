using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class HistoryRecord : BaseEntity
{
    public DateOnly Date { get; private set; }
    public int CurrentDoneItems { get; private set; }
    public int CurrentTotalItems { get; private set; }

    public Guid SubGoalId { get; private set; }
    public SubGoal SubGoal { get; private set; } = null!;
}
