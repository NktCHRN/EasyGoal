using AutoMapper;
using EasyGoal.Backend.Application.Features.SubGoals.Commands;
using EasyGoal.Backend.Application.Features.SubGoals.Dto;
using EasyGoal.Backend.WebApi.Contracts.Requests.SubGoals;
using EasyGoal.Backend.WebApi.Contracts.Responses.SubGoals;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class SubGoalMappingProfile : Profile
{
    public SubGoalMappingProfile()
    {
        CreateMap<CreateSubGoalRequest, CreateSubGoalCommand>();
        CreateMap<SubGoalCreatedDto, SubGoalCreatedResponse>();
        
        CreateMap<UpdateSubGoalRequest, UpdateSubGoalCommand>();

        CreateMap<SubGoalDto, SubGoalResponse>();
        CreateMap<SubGoalsDto, SubGoalsResponse>();
    }
}
