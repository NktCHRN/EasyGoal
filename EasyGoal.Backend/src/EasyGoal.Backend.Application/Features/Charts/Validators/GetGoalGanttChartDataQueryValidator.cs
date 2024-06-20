using EasyGoal.Backend.Application.Features.Charts.Queries;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Charts.Validators;
public sealed class GetGoalGanttChartDataQueryValidator : AbstractValidator<GetGoalGanttChartDataQuery>
{
    public GetGoalGanttChartDataQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => x.End - x.Start >= TimeSpan.FromDays(7))
            .WithMessage("Charts can be built for at least one week.");
    }
}
