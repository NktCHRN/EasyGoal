using MediatR;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed record UpdateSubTaskCommand : IRequest
{
    public Guid TaskId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
