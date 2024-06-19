using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record UpdateTaskStatusCommand(Guid Id, bool IsCompleted) : IRequest
{
}
