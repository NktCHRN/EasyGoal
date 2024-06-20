using EasyGoal.Backend.Application.Features.Calendars.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Calendars.Queries;
public sealed record GetDailyCalendarQuery(DateTimeOffset UserCurrentDateTime) : IRequest<DailyCalendarEventsDto>
{
}
