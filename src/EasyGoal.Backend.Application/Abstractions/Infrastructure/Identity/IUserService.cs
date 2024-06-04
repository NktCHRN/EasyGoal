using EasyGoal.Backend.Application.Features.Account.Dto;

namespace EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
public interface IUserService
{
    Task<AccountDto> RegisterAsync(string email, string name, string password);
    Task<LoginResultDto> LoginAsync(string email, string password);
    Task<TokensDto> Refresh(TokensDto tokens);
    Task Revoke(string refreshToken);
}
