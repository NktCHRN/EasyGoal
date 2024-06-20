using AutoMapper;
using EasyGoal.Backend.Application.Features.Charts.Queries;
using EasyGoal.Backend.WebApi.Contracts.Responses.Charts;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class ChartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ChartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("gantt/goals/{goalId}")]
    [ProducesResponseType(typeof(ApiResponse<GanttChartDataResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetGanttChartForGoal(
        [FromRoute] Guid goalId,
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        [FromQuery] string ianaTimeZone)
    {
        var query = new GetGoalGanttChartDataQuery(goalId, start, end, ianaTimeZone);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<GanttChartDataResponse>(result);

        return OkResponse(response);
    }

    [HttpGet("burn-up/goals/{goalId}")]
    [ProducesResponseType(typeof(ApiResponse<BurnUpChartDataResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBurnUpChartForGoal(
        [FromRoute] Guid goalId,
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end,
        [FromQuery] string ianaTimeZone,
        [FromQuery] int pointsCount = 10)
    {
        var query = new GetGoalBurnUpChartDataQuery(goalId, start, end, ianaTimeZone, pointsCount);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<BurnUpChartDataResponse>(result);

        return OkResponse(response);
    }
}
