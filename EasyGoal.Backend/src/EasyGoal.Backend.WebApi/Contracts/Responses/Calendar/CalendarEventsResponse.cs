namespace EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;

public sealed record CalendarEventsResponse(IEnumerable<CalendarTaskResponse> Events)
{
}
