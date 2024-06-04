using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand>
{
    private readonly IAccountService _userService;

    public RevokeRefreshTokenCommandHandler(IAccountService userService)
    {
        _userService = userService;
    }

    public async Task Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        await _userService.Revoke(request.RefreshToken);
    }
}
