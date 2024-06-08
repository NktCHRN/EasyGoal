using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class SubTask : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    public Guid TaskId { get; private set; }
    public Task Task { get; private set; } = null!;
}
