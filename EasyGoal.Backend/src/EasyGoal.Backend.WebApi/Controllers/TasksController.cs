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

    [HttpPut("{id}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTaskStatus([FromRoute] Guid id, [FromBody] UpdateTaskStatusRequest request)
    {
        var command = new UpdateTaskStatusCommand(id, request.IsCompleted);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
    {
        var command = new DeleteTaskCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{taskId}/sub-tasks")]
    [ProducesResponseType(typeof(ApiResponse<SubTaskCreatedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSubTask([FromRoute] Guid taskId, [FromBody] CreateSubTaskRequest request)
    {
        var command = _mapper.Map<CreateSubTaskCommand>(request);
        command.TaskId = taskId;

        var result = await _mediator.Send(command);

        var response = _mapper.Map<SubTaskCreatedResponse>(result);

        return OkResponse(response);
    }

    [HttpPut("{taskId}/sub-tasks/{subTaskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSubTask([FromRoute] Guid taskId, [FromRoute] Guid subTaskId, [FromBody] UpdateSubTaskRequest request)
    {
        var command = _mapper.Map<UpdateSubTaskCommand>(request);
        command.Id = subTaskId;
        command.TaskId = taskId;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{taskId}/sub-tasks/{subTaskId}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSubTaskStatus([FromRoute] Guid taskId, [FromRoute] Guid subTaskId, [FromBody] UpdateSubTaskStatusRequest request)
    {
        var command = new UpdateSubTaskStatusCommand(taskId, subTaskId, request.IsCompleted);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{taskId}/sub-tasks/{subTaskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<object?>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSubTask([FromRoute] Guid taskId, [FromRoute] Guid subTaskId)
    {
        var command = new DeleteSubTaskCommand(taskId, subTaskId);

        await _mediator.Send(command);

        return NoContent();
    }
}
