using AutoMapper;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Application.Features.SubGoals.MappingProfiles;
public class SubGoalMappingProfile : Profile
{
    public SubGoalMappingProfile()
    {
        CreateMap<SubGoal, SubGoalDto>();
    }
}
