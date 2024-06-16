using EasyGoal.Backend.Domain.Abstractions.Entities;
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

    public void Delete(Guid userId)
    {
        ValidateOwner(userId);

        foreach (var task in Tasks)
        {
            task.Delete(userId);
        }

        Delete();
    }

    public void ValidateOwner(Guid userId)
    {
        if (Goal.UserId != userId)
        {
            throw new ForbiddenForUserException("This subgoal does not belong to current user");
        }
    }
}
