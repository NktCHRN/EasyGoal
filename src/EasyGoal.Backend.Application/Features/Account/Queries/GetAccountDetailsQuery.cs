using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Queries;
public sealed record GetAccountDetailsQuery : IRequest<AccountDto>;
