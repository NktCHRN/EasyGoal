using EasyGoal.Backend.Application.Features.Goals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed record CreateGoalCommand(string Name, DateOnly Deadline) : IRequest<GoalCreatedDto>
{
}
