namespace EasyGoal.Backend.WebApi.Contracts.Responses.Goals;

public sealed record GoalDetailsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; }
    public DateOnly Deadline { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public string? Description { get; set; }
    public int DoneTasks { get; set; }
    public int TotalTasks { get; set; }
    public decimal DoneTasksPercentage { get; set; }
    public decimal TasksPerDay { get; set; }
    public string? FileName { get; set; }
    public string? DiplayFileName { get; set; }
    public int FilesCount { get; set; }
}
