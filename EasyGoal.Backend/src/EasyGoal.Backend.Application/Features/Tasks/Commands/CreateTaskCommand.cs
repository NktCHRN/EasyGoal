using EasyGoal.Backend.Application.Features.Tasks.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record CreateTaskCommand : IRequest<TaskCreatedDto>
{
    public Guid SubGoalId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; private set; }
}
