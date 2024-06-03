using AutoMapper;
using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.WebApi.Contracts.Requests.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AccountController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiResponse<AccountRegisteredResponse>), 200)]
    [ProducesResponseType(typeof(ApiResponse<AccountRegisteredResponse>), 400)]
    [ProducesResponseType(typeof(ApiResponse<AccountRegisteredResponse>), 500)]
    public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request)
    {
        var command = _mapper.Map<RegisterAccountCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<AccountRegisteredResponse>(dto));
    }
}
