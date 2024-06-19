using EasyGoal.Backend.Domain.Abstractions.DomainEvents;

namespace EasyGoal.Backend.Domain.DomainEvents;
public sealed record SubGoalDeletedEvent(Guid SubGoalId) : BaseEvent
{
}
