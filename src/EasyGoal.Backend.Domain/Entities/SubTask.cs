using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities;
public class SubTask : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
}
