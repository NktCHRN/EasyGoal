using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Specifications.DecisionHelper;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Queries;
public sealed class GetDecisionHelperCriteriaQueryHandler : IRequestHandler<GetDecisionHelperCriteriaQuery, DecisionHelperCriteriaDto>
{
    private readonly IRepository<DecisionHelperCriterion> _decisionHelperCriterionRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;

    public GetDecisionHelperCriteriaQueryHandler(IRepository<DecisionHelperCriterion> decisionHelperCriterionRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _decisionHelperCriterionRepository = decisionHelperCriterionRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<DecisionHelperCriteriaDto> Handle(GetDecisionHelperCriteriaQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();

        var criteria = await _decisionHelperCriterionRepository.ListAsync(new DecisionHelperCriteriaByUserIdAsNoTrackingSpec(userId), cancellationToken);

        var dto = new DecisionHelperCriteriaDto
        {
            Criteria = _mapper.Map<IReadOnlyList<DecisionHelperCriterionDto>>(criteria)
        };

        return dto;
    }
}
