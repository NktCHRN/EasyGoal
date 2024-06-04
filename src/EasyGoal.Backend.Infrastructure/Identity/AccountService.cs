using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Extensions;
using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.Application.Features.Account.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Security;
using System.Security.Claims;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class AccountService : IAccountService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly TimeProvider _timeProvider;
    private readonly TokenProvidersOptions _tokenProvidersOptions;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<RefreshToken> _refreshTokenRepository;
    private readonly IMapper _mapper;

    public AccountService(UserManager<IdentityApplicationUser> userManager, IJwtTokenProvider jwtTokenProvider, TimeProvider timeProvider, IOptions<TokenProvidersOptions> tokenProvidersOptions, ICurrentApplicationUser currentApplicationUser, IRepository<RefreshToken> refreshTokenRepository, IMapper mapper)
    {
        _userManager = userManager;
        _jwtTokenProvider = jwtTokenProvider;
        _timeProvider = timeProvider;
        _tokenProvidersOptions = tokenProvidersOptions.Value;
        _currentApplicationUser = currentApplicationUser;
        _refreshTokenRepository = refreshTokenRepository;
        _mapper = mapper;
    }

    public async Task<AccountDto> RegisterAsync(string email, string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EntityValidationFailedException("Name must not be empty.");
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
            throw new EntityValidationFailedException(IdentityUtilities.IdentityFailuresToString(userCreationResults.Errors));
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
            throw new UserUnauthorizedException("Wrong email or password");
        }

        var refreshToken = _jwtTokenProvider.GenerateRefreshToken();
        await _refreshTokenRepository.AddAsync(new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
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

    public async Task<TokensDto> Refresh(TokensDto tokens)
    {
        try
        {
            var principal = _jwtTokenProvider.GetPrincipalFromExpiredToken(tokens.AccessToken);
            var userId = principal?.GetId() ?? throw new EntityNotFoundException("No info about user id in the token");
            var refreshTokenDataModel = await _refreshTokenRepository.FirstOrDefaultAsync(new RefreshTokenByUserIdAndTokenSpec(userId, tokens.RefreshToken));
            if (refreshTokenDataModel is null
                || refreshTokenDataModel.ExpiryTime <= _timeProvider.GetUtcNow())
            {
                throw new EntityValidationFailedException("Refresh token is expired.");
            }

            var newAccessToken = _jwtTokenProvider.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _jwtTokenProvider.GenerateRefreshToken();
            refreshTokenDataModel.Token = newRefreshToken;
            await _refreshTokenRepository.UpdateAsync(refreshTokenDataModel);

            return new TokensDto(newAccessToken, newRefreshToken);
        }
        catch (SecurityException ex)
        {
            throw new EntityValidationFailedException(ex.Message, ex);
        }
    }

    public async Task Revoke(string refreshToken)
    {
        var userId = _currentApplicationUser.Id ?? throw new EntityNotFoundException("User or refresh token was not found");

        var refreshTokenDataModel = await _refreshTokenRepository.FirstOrDefaultAsync(new RefreshTokenByUserIdAndTokenSpec(userId, refreshToken))
            ?? throw new EntityNotFoundException("User or refresh token was not found");

        await _refreshTokenRepository.DeleteAsync(refreshTokenDataModel);
    }

    public async Task<AccountDto> GetAccountDetails()
    {
        var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == _currentApplicationUser.Id)
            ?? throw new EntityNotFoundException("User was not found");

        return _mapper.Map<AccountDto>(user);
    }

    public async Task<AccountDto> UpdateAccountDetails(UpdateAccountDetailsCommand updateAccountCommand)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == _currentApplicationUser.Id)
            ?? throw new EntityNotFoundException("User was not found");

        user.Name = updateAccountCommand.Name;

        await _userManager.UpdateAsync(user);

        return _mapper.Map<AccountDto>(user);
    }
}
