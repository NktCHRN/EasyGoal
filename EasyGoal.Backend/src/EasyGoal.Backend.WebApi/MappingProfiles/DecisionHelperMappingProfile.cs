using AutoMapper;
using EasyGoal.Backend.Application.Features.DecisionHelper.Commands;
using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using EasyGoal.Backend.Application.Features.DecisionHelper.Queries;
using EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;
using EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class DecisionHelperMappingProfile : Profile
{
    public DecisionHelperMappingProfile()
    {
        CreateMap<DecisionHelperCriteriaDto, DecisionHelperCriteriaResponse>();
        CreateMap<DecisionHelperCriterionDto, DecisionHelperCriterionResponse>();

        CreateMap<UpdateDecisionHelperCriterionRequest, UpdateDecisionHelperCriterionDto>();
        CreateMap<UpdateDecisionHelperCriteriaRequest, UpdateDecisionHelperCriteriaCommand>();

        CreateMap<GetObjectivesRankingRequest, GetObjectivesRankingQuery>();
        CreateMap<ObjectiveEstimates, ObjectiveEstimatesDto>();
        CreateMap<RankedObjectiveDto, RankedObjectiveResponse>();
        CreateMap<ObjectivesRankingDto, ObjectivesRankingResponse>();
    }
}
