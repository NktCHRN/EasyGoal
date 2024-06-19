using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record UpdateTaskCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; private set; }
    public string? Notes { get; set; }
}
