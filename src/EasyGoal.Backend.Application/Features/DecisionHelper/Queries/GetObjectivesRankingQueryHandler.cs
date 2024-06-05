using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Specifications.DecisionHelper;
using EasyGoal.Backend.Domain.Utilities;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Queries;
public sealed class GetObjectivesRankingQueryHandler : IRequestHandler<GetObjectivesRankingQuery, ObjectivesRankingDto>
{
    private readonly IRepository<DecisionHelperCriterion> _decisionHelperCriterionRepository;
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IMapper _mapper;
    private readonly IDecisionHelper _decisionHelper;

    public GetObjectivesRankingQueryHandler(IRepository<DecisionHelperCriterion> decisionHelperCriterionRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper, IDecisionHelper decisionHelper)
    {
        _decisionHelperCriterionRepository = decisionHelperCriterionRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
        _decisionHelper = decisionHelper;
    }

    public async Task<ObjectivesRankingDto> Handle(GetObjectivesRankingQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();

        var criteria = await _decisionHelperCriterionRepository.ListAsync(new DecisionHelperCriteriaByUserIdAsNoTrackingSpec(userId), cancellationToken);

        var ranking = _decisionHelper.GetRanking(_mapper.Map<IReadOnlyList<ObjectiveEstimates>>(request.Estimates), criteria);

        var dto = new ObjectivesRankingDto
        {
            Ranking = _mapper.Map<IReadOnlyList<RankedObjectiveDto>>(ranking)
        };

        return dto;
    }
}
