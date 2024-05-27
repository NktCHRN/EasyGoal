namespace EasyGoal.Backend.Domain.Abstractions.Entities;
public abstract class BaseEntity : ISoftDeleteEntity
{
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; set; }
}
