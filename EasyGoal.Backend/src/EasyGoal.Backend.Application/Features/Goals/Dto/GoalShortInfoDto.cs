namespace EasyGoal.Backend.Application.Features.Goals.Dto;
public sealed record GoalShortInfoDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
    public string? Description { get; set; }
    public int DoneTasks { get; set; }
    public int TotalTasks { get; set; }
    public double DoneTasksPercentage { get; set; }
    public string? FileName { get; set; }
    public string? DiplayFileName { get; set; }
}
