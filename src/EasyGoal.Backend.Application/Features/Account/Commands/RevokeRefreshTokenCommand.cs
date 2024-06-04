using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed record RevokeRefreshTokenCommand(string RefreshToken) : IRequest;
