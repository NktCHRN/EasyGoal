using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public record RegisterAccountCommand(string Email, string Name, string Password) : IRequest<AccountDto>;
