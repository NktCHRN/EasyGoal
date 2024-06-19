using AutoMapper;
using EasyGoal.Backend.Application.Features.Tasks.Commands;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.WebApi.Contracts.Requests.Tasks;
using EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<CreateTaskRequest, CreateTaskCommand>();
        CreateMap<TaskCreatedDto, TaskCreatedResponse>();

        CreateMap<UpdateTaskRequest, UpdateTaskCommand>();
    }
}
