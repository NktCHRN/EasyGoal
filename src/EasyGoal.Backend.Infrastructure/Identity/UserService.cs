﻿using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Extensions;
using EasyGoal.Backend.Application.Features.Account.Dto;
using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Security.Claims;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class UserService : IUserService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly TimeProvider _timeProvider;
    private readonly TokenProvidersOptions _tokenProvidersOptions;

    public UserService(UserManager<IdentityApplicationUser> userManager, IJwtTokenProvider jwtTokenProvider, TimeProvider timeProvider, IOptions<TokenProvidersOptions> tokenProvidersOptions)
    {
        _userManager = userManager;
        _jwtTokenProvider = jwtTokenProvider;
        _timeProvider = timeProvider;
        _tokenProvidersOptions = tokenProvidersOptions.Value;
    }

    public async Task<AccountDto> RegisterAsync(string email, string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new IdentityEntityValidationFailedException("Name must not be empty.");
        }

        var user = new IdentityApplicationUser
        {
            Name = name.Trim(),
            Email = email,
            UserName = email,
            UserCategories = CreateDefaultCategories()
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

    private static IList<Category> CreateDefaultCategories()
    {
        return
            [
                Category.Create("Work", Color.DeepSkyBlue.ToHexString()),
                Category.Create("Study", Color.SaddleBrown.ToHexString()),
                Category.Create("Health", Color.LightGreen.ToHexString()),
            ];
    }

    public async Task<LoginResultDto> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByNameAsync(email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            throw new IdentityEntityValidationFailedException("Wrong email or password");
        }

        var refreshToken = _jwtTokenProvider.GenerateRefreshToken();
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            UserId = user!.Id,
            ExpiryTime = _timeProvider.GetUtcNow().AddDays(_tokenProvidersOptions.RefreshTokenLifetimeInDays)
        });
        return new LoginResultDto()
        {
            AccessToken = _jwtTokenProvider.GenerateAccessToken(GetClaims(user!)),
            RefreshToken = refreshToken
        };
    }

    private static IEnumerable<Claim> GetClaims(IdentityApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Email!),
            new (ClaimTypes.Email, user.Email!),
            new (ClaimTypes.GivenName, user.Name)
        };
        return claims;
    }
}
