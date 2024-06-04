using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed class RefreshTokensCommandHandler : IRequestHandler<RefreshTokensCommand, TokensDto>
{
    private readonly IAccountService _userService;

    public RefreshTokensCommandHandler(IAccountService userService)
    {
        _userService = userService;
    }

    public async Task<TokensDto> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
    {
        return await _userService.Refresh(new TokensDto(request.AccessToken, request.RefreshToken));
    }
}
