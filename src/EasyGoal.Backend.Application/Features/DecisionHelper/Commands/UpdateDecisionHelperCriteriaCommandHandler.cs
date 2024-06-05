using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.DecisionHelper;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Commands;
public sealed class UpdateDecisionHelperCriteriaCommandHandler : IRequestHandler<UpdateDecisionHelperCriteriaCommand>
{
    private readonly IRepository<DecisionHelperCriterion> _decisionHelperCriterionRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public UpdateDecisionHelperCriteriaCommandHandler(IRepository<DecisionHelperCriterion> decisionHelperCriterionRepository, ICurrentApplicationUser currentApplicationUser)
    {
        _decisionHelperCriterionRepository = decisionHelperCriterionRepository;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task Handle(UpdateDecisionHelperCriteriaCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();

        var currentCriteria = await _decisionHelperCriterionRepository.ListAsync(new DecisionHelperCriteriaByUserIdSpec(userId), cancellationToken);

        var updatedCriteria = new List<DecisionHelperCriterion>();
        var addedCriteria = new List<DecisionHelperCriterion>();
        for (var i = 0; i < request.Criteria.Count; i++)
        {
            var criterionDto = request.Criteria[i];
            DecisionHelperCriterion criterion;
            if (criterionDto.Id.HasValue)
            {
                criterion = currentCriteria.FirstOrDefault(c => c.Id == criterionDto.Id) ?? throw new EntityNotFoundException($"Criterion with id {criterionDto.Id} was not found");
                criterion.Update(i + 1, criterionDto.Name, criterionDto.Weight, criterionDto.Type);
                updatedCriteria.Add(criterion);
            }
            else
            {
                criterion = DecisionHelperCriterion.Create(i + 1, criterionDto.Name, criterionDto.Weight, criterionDto.Type);
                criterion.UserId = userId;
                addedCriteria.Add(criterion);
            }
        }
        DecisionHelperCriterion.ValidateList(updatedCriteria.Concat(addedCriteria));

        foreach (var criterion in currentCriteria.Except(updatedCriteria))
        {
            criterion.Delete();
        }
        
        await _decisionHelperCriterionRepository.AddRangeAsync(addedCriteria, cancellationToken);
    }
}
