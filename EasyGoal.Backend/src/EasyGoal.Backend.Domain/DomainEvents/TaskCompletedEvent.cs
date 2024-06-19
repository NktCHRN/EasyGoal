using EasyGoal.Backend.Domain.Abstractions.DomainEvents;

namespace EasyGoal.Backend.Domain.DomainEvents;
public sealed record TaskCompletedEvent(Guid TaskId, Guid SubGoalId) : BaseEvent
{
}
