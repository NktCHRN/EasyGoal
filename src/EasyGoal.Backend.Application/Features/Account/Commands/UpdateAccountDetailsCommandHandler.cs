using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed class UpdateAccountDetailsCommandHandler : IRequestHandler<UpdateAccountDetailsCommand, AccountDto>
{
    private readonly IAccountService _userService;

    public UpdateAccountDetailsCommandHandler(IAccountService userService)
    {
        _userService = userService;
    }

    public async Task<AccountDto> Handle(UpdateAccountDetailsCommand request, CancellationToken cancellationToken)
    {
        return await _userService.UpdateAccountDetails(request);
    }
}
