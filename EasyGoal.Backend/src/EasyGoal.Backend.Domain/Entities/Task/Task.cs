using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Enums;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class Task : BaseAuditableEntity
{
    public bool IsCompleted { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset? StartTime { get; private set; }
    public DateTimeOffset? EndTime { get; private set; }
    public string? Notes { get; private set; }

    public SynchronisationStatus? GoogleSynchronisationStatus { get; set; }

    public IReadOnlyList<SubTask> SubTasks => _subTasks.AsReadOnly();
    private readonly List<SubTask> _subTasks = [];
    public Guid SubGoalId { get; private set; }
    public SubGoal SubGoal { get; private set; } = null!;

    public void ValidateOwner(Guid userId)
    {
        if (SubGoal.Goal.UserId != userId)
        {
            throw new ForbiddenForUserException("This task does not belong to current user");
        }
    }

    public void Delete(Guid userId)
    {
        ValidateOwner(userId);

        Delete();
    }
}
