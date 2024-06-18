using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.SubGoals.Commands;
public sealed class CreateSubGoalCommandHandler : IRequestHandler<CreateSubGoalCommand, SubGoalCreatedDto>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;

    public CreateSubGoalCommandHandler(ICurrentApplicationUser currentApplicationUser, IRepository<Goal> goalRepository)
    {
        _currentApplicationUser = currentApplicationUser;
        _goalRepository = goalRepository;
    }

    public async Task<SubGoalCreatedDto> Handle(CreateSubGoalCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalByIdForAddingSubGoalSpec(request.GoalId), cancellationToken)
            ?? throw new EntityNotFoundException($"Goal with id {request.GoalId} was not found");

        var subGoal = goal.AddSubGoal(request.Name, request.Deadline, userId);

        await _goalRepository.SaveChangesAsync(cancellationToken);

        return new SubGoalCreatedDto(subGoal.Id);
    }
}
