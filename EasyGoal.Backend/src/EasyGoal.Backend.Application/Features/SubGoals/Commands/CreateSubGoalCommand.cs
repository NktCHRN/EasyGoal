using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Commands;
public sealed record CreateSubGoalCommand : IRequest<SubGoalCreatedDto>
{
    public Guid GoalId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Deadline { get; set; }
}
