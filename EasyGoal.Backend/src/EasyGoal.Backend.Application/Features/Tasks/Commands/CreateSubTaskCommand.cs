using EasyGoal.Backend.Application.Features.Tasks.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record CreateSubTaskCommand : IRequest<SubTaskCreatedDto>
{
    public Guid TaskId { get; set; }
    public string Name { get; set; } = string.Empty;
}
