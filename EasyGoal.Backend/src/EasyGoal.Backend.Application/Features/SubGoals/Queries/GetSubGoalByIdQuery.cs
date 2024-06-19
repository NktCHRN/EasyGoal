using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Queries;
public sealed record GetSubGoalByIdQuery(Guid GoalId, Guid Id) : IRequest<SubGoalDto>
{
}
