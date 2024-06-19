using AutoMapper;
using EasyGoal.Backend.Application.Features.Calendars.Queries;
using EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class CalendarsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CalendarsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("weekly")]
    [ProducesResponseType(typeof(ApiResponse<CalendarEventsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetWeeklyCalendar(
        [FromQuery] DateTimeOffset start,
        [FromQuery] DateTimeOffset end)
    {
        var query = new GetWeeklyCalendarQuery(start, end);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<CalendarEventsResponse>(result);

        return OkResponse(response);
    }
}
