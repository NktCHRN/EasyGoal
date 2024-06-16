using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed record DeleteGoalCommand(Guid Id) : IRequest
{
}
