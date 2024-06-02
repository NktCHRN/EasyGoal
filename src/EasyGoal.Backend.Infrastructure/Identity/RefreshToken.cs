using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Infrastructure.Identity;
public class RefreshToken : BaseAuditableEntity
{
    public string Token { get; set; } = string.Empty;

    public DateTimeOffset ExpiryTime { get; set; }

    public Guid UserId { get; set; }
    public IdentityUser User { get; set; } = null!;
}
