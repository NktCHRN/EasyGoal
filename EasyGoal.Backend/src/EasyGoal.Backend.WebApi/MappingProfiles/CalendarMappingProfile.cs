using AutoMapper;
using EasyGoal.Backend.Application.Features.Calendars.Dto;
using EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class CalendarMappingProfile : Profile
{
    public CalendarMappingProfile() 
    {
        CreateMap<CalendarTaskDto, CalendarTaskResponse>();
        CreateMap<CalendarEventsDto, CalendarEventsResponse>();
    }
}
