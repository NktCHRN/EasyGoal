using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
{
    private readonly IUserService _userService;

    public LoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _userService.LoginAsync(request.Email, request.Password);
    }
}
