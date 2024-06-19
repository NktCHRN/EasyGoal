using EasyGoal.Backend.Application.Abstractions.Infrastructure.Database;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;
using System.Transactions;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Tasks.Commands;
public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskCreatedDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly ITransactionProvider _transactionProvider;

    public CreateTaskCommandHandler(IRepository<Task> taskRepository, IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser, ITransactionProvider transactionProvider)
    {
        _taskRepository = taskRepository;
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
        _transactionProvider = transactionProvider;
    }

    public async Task<TaskCreatedDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _transactionProvider.BeginTransactionAsync();
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalBySubGoalIdForOwnerValidationSpec(request.SubGoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Sub-goal with id {request.SubGoalId} was not found");

        goal.ValidateOwner(userId);

        var task = Task.Create(request.Name, request.StartTime, request.EndTime, request.SubGoalId);

        await _taskRepository.AddAsync(task, cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new TaskCreatedDto(task.Id);
    }
}
