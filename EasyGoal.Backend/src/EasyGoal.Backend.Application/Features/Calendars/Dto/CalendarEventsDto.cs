namespace EasyGoal.Backend.Application.Features.Calendars.Dto;
public sealed record CalendarEventsDto(IReadOnlyList<CalendarTaskDto> Events)
{
}
