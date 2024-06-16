using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Commands;
public sealed class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;

    public UpdateGoalCommandHandler(ICurrentApplicationUser currentApplicationUser, IRepository<Goal> goalRepository)
    {
        _currentApplicationUser = currentApplicationUser;
        _goalRepository = goalRepository;
    }

    public async Task Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goal = await _goalRepository.FirstOrDefaultAsync(new GoalByIdForUpdateSpec(request.Id), cancellationToken)
            ?? throw new EntityNotFoundException($"Goal with id {request.Id} was not found");

        goal.Update(request.Name, request.Deadline, request.Description, userId);

        await _goalRepository.SaveChangesAsync(cancellationToken);
    }
}
