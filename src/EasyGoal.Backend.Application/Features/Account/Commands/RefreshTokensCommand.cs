using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed record RefreshTokensCommand(string AccessToken, string RefreshToken) : IRequest<TokensDto>;
