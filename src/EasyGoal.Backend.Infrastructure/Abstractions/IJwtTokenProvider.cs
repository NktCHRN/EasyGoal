using System.Security.Claims;

namespace EasyGoal.Backend.Infrastructure.Abstractions;
public interface IJwtTokenProvider
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    public string GenerateRefreshToken();

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
