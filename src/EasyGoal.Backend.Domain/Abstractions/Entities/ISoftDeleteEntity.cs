namespace EasyGoal.Backend.Domain.Abstractions.Entities;
public interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
}
