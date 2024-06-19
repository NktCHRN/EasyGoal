using EasyGoal.Backend.Domain.Abstractions.DomainEvents;

namespace EasyGoal.Backend.Domain.DomainEvents;
public sealed record TaskDeletedEvent(Guid TaskId, Guid SubGoalId, bool IsCompleted) : BaseEvent
{
}
