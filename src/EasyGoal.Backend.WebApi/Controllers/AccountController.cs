using AutoMapper;
using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.Application.Features.Account.Dto;
using EasyGoal.Backend.WebApi.Contracts.Requests.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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


    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), 200)]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), 400)]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), 401)]
    [ProducesResponseType(typeof(ApiResponse<LoginResponse>), 500)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<LoginResultDto>(dto));
    }

    [HttpPost("tokens/refresh")]
    [ProducesResponseType(typeof(ApiResponse<TokensResponse>), 200)]
    [ProducesResponseType(typeof(ApiResponse<TokensResponse>), 400)]
    [ProducesResponseType(typeof(ApiResponse<TokensResponse>), 500)]
    public async Task<IActionResult> RefreshTokens([FromBody] RefreshTokensRequest request)
    {
        var command = _mapper.Map<RefreshTokensCommand>(request);

        var dto = await _mediator.Send(command);

        return OkResponse(_mapper.Map<TokensResponse>(dto));
    }

    [Authorize]
    [HttpPost("tokens/revoke")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ApiResponse<object?>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object?>), 500)]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeRefreshTokenRequest request)
    {
        var command = _mapper.Map<RevokeRefreshTokenCommand>(request);

        await _mediator.Send(command);

        return NoContentResponse();
    }

    //[Authorize]
    //[HttpGet("details")]
    //[ProducesResponseType(typeof(UserResponse), 200)]
    //[ProducesResponseType(typeof(ErrorResponse), 404)]
    //[ProducesResponseType(typeof(ErrorResponse), 500)]
    //public async Task<IActionResult> GetDetails()
    //{
    //    var result = await _userService.GetDetails(User.GetId().GetValueOrDefault());

    //    return Ok(_mapper.Map<UserResponse>(result));
    //}

    //[Authorize]
    //[HttpPut("details")]
    //[ProducesResponseType(typeof(UserResponse), 200)]
    //[ProducesResponseType(typeof(ErrorResponse), 400)]
    //[ProducesResponseType(typeof(ErrorResponse), 404)]
    //[ProducesResponseType(typeof(ErrorResponse), 500)]
    //public async Task<IActionResult> UpdateDetails([FromBody] UpdateUserRequest request)
    //{
    //    var result = await _userService.UpdateDetails(User.GetId().GetValueOrDefault(), _mapper.Map<UpdateUserDto>(request));

    //    return Ok(_mapper.Map<UserResponse>(result));
    //}
}
