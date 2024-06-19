using EasyGoal.Backend.Application.Features.Calendars.Queries;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Calendars.Validators;
public sealed class GetWeeklyCalendarQueryValidator : AbstractValidator<GetWeeklyCalendarQuery>
{
    public GetWeeklyCalendarQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => x.End - x.Start != TimeSpan.FromDays(7))
            .WithMessage("Calendar is available for week only. Start is inclusive, end is exclusive.");
    }
}
