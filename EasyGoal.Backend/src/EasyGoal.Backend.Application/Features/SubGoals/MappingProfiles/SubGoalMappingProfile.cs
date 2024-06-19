using AutoMapper;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;

namespace EasyGoal.Backend.Application.Features.SubGoals.MappingProfiles;
public class SubGoalMappingProfile : Profile
{
    public SubGoalMappingProfile()
    {
        CreateMap<SubGoalMappingProfile, SubGoalDto>();
    }
}
