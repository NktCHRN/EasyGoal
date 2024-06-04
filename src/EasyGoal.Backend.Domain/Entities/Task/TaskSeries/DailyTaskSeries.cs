namespace EasyGoal.Backend.Domain.Entities.Task.TaskSeries;
public class DailyTaskSeries : TaskSeries
{
    public DateOnly StartDate { get; private set; }
    public TimeOnly? StartTime { get; private set; }
}
