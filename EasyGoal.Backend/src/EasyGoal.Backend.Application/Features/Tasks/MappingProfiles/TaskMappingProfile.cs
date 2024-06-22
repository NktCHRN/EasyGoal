using AutoMapper;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.Domain.Entities.Task;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Tasks.MappingProfiles;
public sealed class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<Task, TaskShortInfoDto>();
        CreateMap<Task, TaskDetailsDto>();

        CreateMap<SubTask, SubTaskDto>();
    }
}
