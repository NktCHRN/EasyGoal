using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
{
    private readonly IRepository<Goal> _goalRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public DeleteGoalCommandHandler(IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalByIdForDeleteSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Goal with id {request.Id} was not found");

        goal.Delete(userId);

        await _goalRepository.SaveChangesAsync(cancellationToken);
    }
}
