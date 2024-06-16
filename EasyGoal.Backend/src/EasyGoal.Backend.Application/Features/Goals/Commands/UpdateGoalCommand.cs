using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed record UpdateGoalCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
    public string? Description { get; set; }
}
