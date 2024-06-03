using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, AccountDto>
{
    private readonly IUserService _userService;

    public RegisterAccountCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AccountDto> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        return await _userService.RegisterAsync(request.Email, request.Name, request.Password);
    }
}
