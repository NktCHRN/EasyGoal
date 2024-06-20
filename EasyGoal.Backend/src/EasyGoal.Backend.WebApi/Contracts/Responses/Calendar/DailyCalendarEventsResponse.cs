using EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

namespace EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;

public sealed record DailyCalendarEventsResponse(IEnumerable<TaskShortInfoResponse> Events)
{
}
