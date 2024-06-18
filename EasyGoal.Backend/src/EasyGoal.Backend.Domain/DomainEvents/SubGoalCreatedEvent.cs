using EasyGoal.Backend.Domain.Abstractions.DomainEvents;

namespace EasyGoal.Backend.Domain.DomainEvents;
public sealed record SubGoalCreatedEvent(Guid SubGoalId) : BaseEvent
{
}
