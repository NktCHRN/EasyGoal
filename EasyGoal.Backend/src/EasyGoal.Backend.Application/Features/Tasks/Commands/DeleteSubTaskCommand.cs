using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record DeleteSubTaskCommand(Guid TaskId, Guid Id) : IRequest
{
}
