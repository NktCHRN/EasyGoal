namespace EasyGoal.Backend.Infrastructure.Identity.Entities;
public class RefreshToken
{
    public Guid Id { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTimeOffset ExpiryTime { get; set; }

    public Guid UserId { get; set; }
    public IdentityApplicationUser User { get; set; } = null!;
}
