using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using Microsoft.AspNetCore.Identity;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class UserService : IUserService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;

    public UserService(UserManager<IdentityApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AccountDto> RegisterAsync(string email, string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new IdentityEntityValidationFailedException("Name must not be empty.");
        }

        var user = new IdentityApplicationUser
        {
            Name = name,
            Email = email,
            UserName = email
        };

        var userCreationResults = await _userManager.CreateAsync(user, password);
        if (!userCreationResults.Succeeded)
        {
            throw new IdentityEntityValidationFailedException(userCreationResults.Errors);
        }

        return new AccountDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };
    }
}
