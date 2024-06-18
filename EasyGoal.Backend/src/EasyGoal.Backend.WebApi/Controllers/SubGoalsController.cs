using AutoMapper;
using EasyGoal.Backend.Application.Features.SubGoals.Commands;
using EasyGoal.Backend.WebApi.Contracts.Requests.SubGoals;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using EasyGoal.Backend.WebApi.Contracts.Responses.SubGoals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api")]
public sealed class SubGoalsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SubGoalsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("goals/{goalId}/[controller]")]
    [ProducesResponseType(typeof(ApiResponse<SubGoalCreatedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateGoal([FromRoute] Guid goalId, [FromBody] CreateSubGoalRequest request)
    {
        var command = _mapper.Map<CreateSubGoalCommand>(request);
        command.GoalId = goalId;

        var result = await _mediator.Send(command);

        var response = _mapper.Map<SubGoalCreatedResponse>(result);

        return OkResponse(response);
    }
}
