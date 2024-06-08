using AutoMapper;
using EasyGoal.Backend.Application.Features.DecisionHelper.Commands;
using EasyGoal.Backend.Application.Features.DecisionHelper.Queries;
using EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public sealed class DecisionHelperController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DecisionHelperController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("criteria")]
    [ProducesResponseType(typeof(ApiResponse<DecisionHelperCriteriaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetArrangementAsync()
    {
        var query = new GetDecisionHelperCriteriaQuery();

        var dto = await _mediator.Send(query);

        return OkResponse(_mapper.Map<DecisionHelperCriteriaResponse>(dto));
    }

    [HttpPut("criteria")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCriteriaAsync([FromBody] UpdateDecisionHelperCriteriaRequest request)
    {
        var command = _mapper.Map<UpdateDecisionHelperCriteriaCommand>(request);

        await _mediator.Send(command);

        return NoContentResponse();
    }

    [HttpPost("criteria/reset")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ResetCriteriaAsync()
    {
        var command = new ResetDecisionHelperCriteriaCommand();

        await _mediator.Send(command);

        return NoContentResponse();
    }

    [HttpPost("rankings")]
    [ProducesResponseType(typeof(ApiResponse<DecisionHelperCriteriaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetObjectivesRankingAsync([FromBody] GetObjectivesRankingRequest request)
    {
        var query = _mapper.Map< GetObjectivesRankingQuery>(request);

        var dto = await _mediator.Send(query);

        return OkResponse(_mapper.Map<ObjectivesRankingResponse>(dto));
    }
}
