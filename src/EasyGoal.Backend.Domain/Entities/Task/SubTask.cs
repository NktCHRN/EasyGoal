using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class SubTask : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
}
