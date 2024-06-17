using AutoMapper;
using EasyGoal.Backend.Application.Features.Goals.Commands;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.WebApi.Contracts.Requests.Goals;
using EasyGoal.Backend.WebApi.Contracts.Responses.Goals;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class GoalMappingProfile : Profile
{
    public GoalMappingProfile()
    {
        CreateMap<CreateGoalRequest, CreateGoalCommand>();
        CreateMap<GoalCreatedDto, GoalCreatedResponse>();

        CreateMap<UpdateGoalRequest, UpdateGoalCommand>();

        CreateMap<UserGoalsDto, UserGoalsResponse>();
        CreateMap<GoalShortInfoDto, GoalShortInfoResponse>();
        CreateMap<GoalDetailsDto, GoalDetailsResponse>();
    }
}
