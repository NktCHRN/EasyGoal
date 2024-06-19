using EasyGoal.Backend.Application.Features.Tasks.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Queries;
public sealed record GetTasksBySubGoalIdQuery(Guid SubGoalId) : IRequest<TasksDto>
{
}
