using Ardalis.Specification;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class RefreshTokenByUserIdAndTokenSpec : SingleResultSpecification<RefreshToken>
{
    public RefreshTokenByUserIdAndTokenSpec(Guid userId, string token)
    {
        Query.Where(r => r.UserId == userId && r.Token == token);
    }
}
