using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Tasks.Queries;
public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDetailsDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;

    public GetTaskByIdQueryHandler(IRepository<Task> taskRepository, IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<TaskDetailsDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var task = await _taskRepository.FirstOrDefaultAsync(new TaskByIdAsNoTrackingSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Task with id {request.Id} was not found");
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalBySubGoalIdForOwnerValidationSpec(task.SubGoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {task.SubGoalId} was not found");

        goal.ValidateOwner(userId);

        return _mapper.Map<TaskDetailsDto>(task);
    }
}
