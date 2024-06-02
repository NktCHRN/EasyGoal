using EasyGoal.Backend.Application.Features.Account.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Account.Commands;
public record RegisterAccountCommand : IRequest<AccountDto>
{
    public string Email { get; set; } = string.Empty;
    public string Name {  get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
