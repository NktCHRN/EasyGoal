namespace EasyGoal.Backend.Application.Features.Calendars.Dto;
public sealed record WeeklyCalendarEventsDto(IReadOnlyList<WeeklyCalendarTaskDto> Events)
{
}
