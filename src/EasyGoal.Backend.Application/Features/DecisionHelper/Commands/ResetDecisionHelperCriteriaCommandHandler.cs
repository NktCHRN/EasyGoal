using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Specifications.DecisionHelper;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Commands;
public sealed class ResetDecisionHelperCriteriaCommandHandler : IRequestHandler<ResetDecisionHelperCriteriaCommand>
{
    private readonly IRepository<DecisionHelperCriterion> _decisionHelperCriterionRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public ResetDecisionHelperCriteriaCommandHandler(IRepository<DecisionHelperCriterion> decisionHelperCriterionRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _decisionHelperCriterionRepository = decisionHelperCriterionRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task Handle(ResetDecisionHelperCriteriaCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();

        var currentCriteria = await _decisionHelperCriterionRepository.ListAsync(new DecisionHelperCriteriaByUserIdSpec(userId), cancellationToken);

        foreach (var currentCriterion in currentCriteria)
        {
            currentCriterion.Delete();
        }

        var defaultCriteria = DecisionHelperCriterion.DefaultCriteria;

        foreach (var defaultCriterion in defaultCriteria)
        {
            defaultCriterion.UserId = userId;
        }

        await _decisionHelperCriterionRepository.AddRangeAsync(defaultCriteria, cancellationToken);
    }
}
