using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Commands;
public sealed record DeleteSubGoalCommand : IRequest
{
    public Guid GoalId { get; set; }
    public Guid Id { get; set; }
}
