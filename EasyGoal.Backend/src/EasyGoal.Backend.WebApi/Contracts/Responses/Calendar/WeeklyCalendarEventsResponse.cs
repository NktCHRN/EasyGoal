namespace EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;

public sealed record WeeklyCalendarEventsResponse(IEnumerable<WeeklyCalendarTaskResponse> Events)
{
}
