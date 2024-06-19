namespace EasyGoal.Backend.WebApi.Contracts.Responses.SubGoals;

public sealed record SubGoalResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
    public int DoneTasks { get; set; }
    public int TotalTasks { get; set; }
}
