using EasyGoal.Backend.Application.Features.Tasks.Dto;

namespace EasyGoal.Backend.Application.Features.Calendars.Dto;
public sealed record DailyCalendarEventsDto(IReadOnlyList<TaskShortInfoDto> Events)
{
}
