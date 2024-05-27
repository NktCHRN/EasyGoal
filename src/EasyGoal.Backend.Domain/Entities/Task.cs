namespace EasyGoal.Backend.Domain.Entities;
public class Task
{
    public DateTimeOffset? StartTime { get; private set; }
    public DateTimeOffset? EndTime { get; private set; }
}
