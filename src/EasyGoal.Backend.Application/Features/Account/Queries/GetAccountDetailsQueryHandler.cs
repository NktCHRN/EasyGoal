using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Queries;
public sealed class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDto>
{
    private readonly IAccountService _accountService;

    public GetAccountDetailsQueryHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<AccountDto> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _accountService.GetAccountDetails();
    }
}
