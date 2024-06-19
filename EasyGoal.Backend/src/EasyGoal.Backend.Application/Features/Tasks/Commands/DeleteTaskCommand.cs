using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record DeleteTaskCommand(Guid Id) : IRequest
{
}
