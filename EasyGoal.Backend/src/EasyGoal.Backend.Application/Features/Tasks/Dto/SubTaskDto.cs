namespace EasyGoal.Backend.Application.Features.Tasks.Dto;
public sealed record SubTaskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
