using EasyGoal.Backend.Domain.Abstractions.Entities;
using MassTransit;

namespace EasyGoal.Backend.Infrastructure.Identity;
public class RefreshToken : ISoftDeletableEntity
{
    public Guid Id { get; set; } = NewId.NextSequentialGuid();

    public string Token { get; set; } = string.Empty;

    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public IdentityApplicationUser User { get; set; } = null!;
}
