namespace EasyGoal.Backend.Application.Features.Tasks.Dto;
public sealed record TaskDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
    public int DoneSubTasks { get; set; }
    public int TotalSubTasks { get; set; }
    public string? Notes { get; set; }
}
