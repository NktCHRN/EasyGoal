using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Commands;
public sealed record UpdateSubGoalCommand : IRequest
{
    public Guid GoalId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
}
