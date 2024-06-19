using AutoMapper;
using EasyGoal.Backend.Application.Features.Tasks.Commands;
using EasyGoal.Backend.WebApi.Contracts.Requests.Tasks;
using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class TasksController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TasksController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("~/api/sub-goals/{subGoalId}/[controller]")]
    [ProducesResponseType(typeof(ApiResponse<TaskCreatedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateTask([FromRoute] Guid subGoalId, [FromBody] CreateTaskRequest request)
    {
        var command = _mapper.Map<CreateTaskCommand>(request);
        command.SubGoalId = subGoalId;

        var result = await _mediator.Send(command);

        var response = _mapper.Map<TaskCreatedResponse>(result);

        return OkResponse(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] UpdateTaskRequest request)
    {
        var command = _mapper.Map<UpdateTaskCommand>(request);
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }
}
