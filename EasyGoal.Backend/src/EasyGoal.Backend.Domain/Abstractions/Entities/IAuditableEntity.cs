namespace EasyGoal.Backend.Domain.Abstractions.Entities;
public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; set; }

    string? CreatedBy { get; set; }

    DateTimeOffset? ModifiedAt { get; set; }

    string? ModifiedBy { get; set; }
}
