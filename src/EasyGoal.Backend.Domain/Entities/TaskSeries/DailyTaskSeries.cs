namespace EasyGoal.Backend.Domain.Entities.TaskSeries;
public class DailyTaskSeries : TaskSeries
{
    public DateOnly StartDate { get; private set; }
    public TimeOnly? StartTime { get; private set; }
}
