namespace EasyGoal.Backend.Domain.Abstractions.Entities;
public interface ISoftDeletableEntity
{
    bool IsDeleted { get; set; }
}
