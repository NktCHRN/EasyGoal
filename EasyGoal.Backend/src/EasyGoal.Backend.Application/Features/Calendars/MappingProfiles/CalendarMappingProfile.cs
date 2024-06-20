using AutoMapper;
using EasyGoal.Backend.Application.Features.Calendars.Dto;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Calendars.MappingProfiles;
public sealed class CalendarMappingProfile : Profile
{
    public CalendarMappingProfile()
    {
        CreateMap<Task, WeeklyCalendarTaskDto>()
            .ForMember(d => d.Start, opt => opt.MapFrom(s => s.StartTime))
            .ForMember(d => d.End, opt => opt.MapFrom(s => s.EndTime));
    }
}
