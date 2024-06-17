using AutoMapper;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Application.Features.Goals.MappingProfiles;
public sealed class GoalMappingProfile : Profile
{
    public GoalMappingProfile()
    {
        CreateMap<Goal, GoalShortInfoDto>()
            .ForMember(d => d.DiplayFileName, opt => opt.MapFrom(s => s.PictureLocalFileName));
    }
}
