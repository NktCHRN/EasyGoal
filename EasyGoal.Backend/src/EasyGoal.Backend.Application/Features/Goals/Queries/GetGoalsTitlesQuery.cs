using EasyGoal.Backend.Application.Features.Goals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed record GetGoalsTitlesQuery : IRequest<GoalsTitlesDto>
{
}
