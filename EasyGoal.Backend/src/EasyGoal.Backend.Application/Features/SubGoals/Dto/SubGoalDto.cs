namespace EasyGoal.Backend.Application.Features.SubGoals.Dto;
public sealed record SubGoalDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
    public int DoneTasks { get; set; }
    public int TotalTasks { get; set; }
}
