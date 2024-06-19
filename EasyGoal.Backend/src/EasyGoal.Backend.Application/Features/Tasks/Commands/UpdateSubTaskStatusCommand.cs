using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record UpdateSubTaskStatusCommand(Guid TaskId, Guid Id, bool IsCompleted) : IRequest
{
}
