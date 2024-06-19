using AutoMapper;
using EasyGoal.Backend.Application.Features.SubGoals.Commands;
using EasyGoal.Backend.Application.Features.SubGoals.Queries;
using EasyGoal.Backend.WebApi.Contracts.Requests.SubGoals;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using EasyGoal.Backend.WebApi.Contracts.Responses.SubGoals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/goals/{goalId}/[controller]")]
public sealed class SubGoalsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SubGoalsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<SubGoalsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSubGoals([FromRoute] Guid goalId)
    {
        var query = new GetSubGoalsByGoalIdQuery(goalId);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<SubGoalsResponse>(result);

        return OkResponse(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<SubGoalResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSubGoalById([FromRoute] Guid goalId, [FromRoute] Guid id)
    {
        var query = new GetSubGoalByIdQuery(goalId, id);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<SubGoalResponse>(result);

        return OkResponse(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<SubGoalCreatedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSubGoal([FromRoute] Guid goalId, [FromBody] CreateSubGoalRequest request)
    {
        var command = _mapper.Map<CreateSubGoalCommand>(request);
        command.GoalId = goalId;

        var result = await _mediator.Send(command);

        var response = _mapper.Map<SubGoalCreatedResponse>(result);

        return OkResponse(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSubGoal([FromRoute] Guid goalId, [FromRoute] Guid id, [FromBody] UpdateSubGoalRequest request)
    {
        var command = _mapper.Map<UpdateSubGoalCommand>(request);
        command.GoalId = goalId;
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSubGoal([FromRoute] Guid goalId, [FromRoute] Guid id)
    {
        var command = new DeleteSubGoalCommand
        {
            GoalId = goalId,
            Id = id
        };

        await _mediator.Send(command);

        return NoContent();
    }
}
