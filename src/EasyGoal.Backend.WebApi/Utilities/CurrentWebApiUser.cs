using EasyGoal.Backend.Application.Abstractions.Presentation;
using System.Security.Claims;

namespace EasyGoal.Backend.WebApi.Utilities;

public sealed class CurrentWebApiUser : ICurrentApplicationUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentWebApiUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id
    {
        get
        {
            var parsed = Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            return parsed ? userId : null;
        }
    }

    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

    public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

    public string? FullName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
}
