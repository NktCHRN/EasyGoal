using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.Application.Features.Account.Dto;

namespace EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
public interface IAccountService
{
    Task<AccountDto> RegisterAsync(string email, string name, string password);
    Task<LoginResultDto> LoginAsync(string email, string password);
    Task<TokensDto> Refresh(TokensDto tokens);
    Task Revoke(string refreshToken);
    Task<AccountDto> GetAccountDetails();
    Task<AccountDto> UpdateAccountDetails(UpdateAccountDetailsCommand updateAccountCommand);
}
