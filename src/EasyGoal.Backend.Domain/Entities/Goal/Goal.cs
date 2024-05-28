using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class Goal : BaseAuditableEntity
{
    public Guid UserId { get; set; }
}
