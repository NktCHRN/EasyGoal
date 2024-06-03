using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public record LoginCommand(string Email, string Password) : IRequest<LoginResultDto>;
