using EasyGoal.Backend.Domain.Abstractions.DomainEvents;

namespace EasyGoal.Backend.Domain.DomainEvents;
public sealed record TaskCreatedEvent(Guid TaskId, Guid SubGoalId) : BaseEvent
{
}
