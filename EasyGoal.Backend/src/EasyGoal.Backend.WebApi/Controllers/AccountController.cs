using AutoMapper;
using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.Application.Features.Account.Dto;
using EasyGoal.Backend.Application.Features.Account.Queries;
using EasyGoal.Backend.WebApi.Contracts.Requests.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    [ProducesResponseType(typeof(ApiResponse<AccountRegisteredResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request)
    {
        var command = _mapper.Map<RegisterAccountCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<AccountRegisteredResponse>(dto));
    }


    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<LoginResultDto>(dto));
    }

    [HttpPost("tokens/refresh")]
    [ProducesResponseType(typeof(ApiResponse<TokensResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshTokens([FromBody] RefreshTokensRequest request)
    {
        var command = _mapper.Map<RefreshTokensCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<TokensResponse>(dto));
    }

    [Authorize]
    [HttpPost("tokens/revoke")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeRefreshTokenRequest request)
    {
        var command = _mapper.Map<RevokeRefreshTokenCommand>(request);

        await _mediator.Send(command);

        return NoContentResponse();
    }

    [Authorize]
    [HttpGet("details")]
    [ProducesResponseType(typeof(ApiResponse<AccountResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDetails()
    {
        var query = new GetAccountDetailsQuery();

        var dto = await _mediator.Send(query);

        return OkResponse(_mapper.Map<AccountResponse>(dto));
    }

    [Authorize]
    [HttpPut("details")]
    [ProducesResponseType(typeof(ApiResponse<AccountResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateDetails([FromBody] UpdateAccountDetailsRequest request)
    {
        var command = _mapper.Map<UpdateAccountDetailsCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<AccountResponse>(dto));
    }
}
