using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public sealed record UpdateAccountDetailsCommand(string Name) : IRequest<AccountDto>;
