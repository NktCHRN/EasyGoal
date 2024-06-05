using AutoMapper;
using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.MappingProfiles;
public sealed class DecisionHelperMappingProfile : Profile
{
    public DecisionHelperMappingProfile()
    {
        CreateMap<DecisionHelperCriterion, DecisionHelperCriterionDto>();

        CreateMap<ObjectiveEstimatesDto, ObjectiveEstimates>();
        CreateMap<RankedObjective, RankedObjectiveDto>();
    }
}
