using EasyGoal.Backend.Application.Abstractions.Presentation;
using System.Security.Claims;
using EasyGoal.Backend.Infrastructure.Identity;

namespace EasyGoal.Backend.WebApi.Utilities;

public sealed class CurrentWebApiUser : ICurrentApplicationUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentWebApiUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id => _httpContextAccessor.HttpContext?.User?.GetId();

    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

    public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

    public string? FullName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
}
