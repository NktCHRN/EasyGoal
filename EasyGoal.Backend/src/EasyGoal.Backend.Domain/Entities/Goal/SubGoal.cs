using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class SubGoal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public DateOnly Deadline { get; private set; }

    public Guid GoalId { get; private set; }
    public Goal Goal { get; private set; } = null!;

    public IReadOnlyList<HistoricalRecord> HistoricalRecords => _historicalRecords.AsReadOnly();
    private readonly List<HistoricalRecord> _historicalRecords = [];
    public IReadOnlyList<Task.Task> Tasks => _tasks.AsReadOnly();
    private readonly List<Task.Task> _tasks = [];

    private SubGoal() { }

    internal static SubGoal Create(string name, DateOnly deadline, Goal goal, Guid userId)
    {
        var subGoal = new SubGoal
        {
            Name = name,
            Deadline = deadline,
            Goal = goal
        };
        subGoal.Validate(userId);
        subGoal.AddDomainEvent(new SubGoalCreatedEvent(subGoal.Id));

        return subGoal;
    }

    public void Delete(Guid userId)
    {
        ValidateOwner(userId);

        foreach (var task in Tasks)
        {
            task.Delete(userId);
        }

        Delete();
    }

    private void Validate(Guid userId)
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Sub-goal name must not be empty");
        }

        ValidateOwner(userId);
    }

    public void ValidateOwner(Guid userId)
    {
        if (Goal.UserId != userId)
        {
            throw new ForbiddenForUserException("This sub-goal does not belong to current user");
        }
    }
}
