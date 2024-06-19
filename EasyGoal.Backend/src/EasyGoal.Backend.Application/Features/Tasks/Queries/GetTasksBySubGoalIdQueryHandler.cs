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
public sealed class GetTasksBySubGoalIdQueryHandler : IRequestHandler<GetTasksBySubGoalIdQuery, TasksDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;

    public GetTasksBySubGoalIdQueryHandler(IRepository<Task> taskRepository, IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<TasksDto> Handle(GetTasksBySubGoalIdQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var tasks = await _taskRepository.ListAsync(new TasksBySubGoalIdAsNoTrackingSpec(request.SubGoalId), cancellationToken);
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalBySubGoalIdForOwnerValidationSpec(request.SubGoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {request.SubGoalId} was not found");

        goal.ValidateOwner(userId);

        var tasksDtos = _mapper.Map<IReadOnlyList<TaskShortInfoDto>>(tasks);

        return new TasksDto(tasksDtos);
    }
}
