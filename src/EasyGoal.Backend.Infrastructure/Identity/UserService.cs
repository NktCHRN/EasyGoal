using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class UserService : IUserService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;

    public async Task Register(string email, string name, string password)
    {

    }
}
