using EasyGoal.Backend.Application.Features.Charts.Queries;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Charts.Validators;
public sealed class GetGoalBurnUpChartDataQueryValidator : AbstractValidator<GetGoalBurnUpChartDataQuery>
{
    public GetGoalBurnUpChartDataQueryValidator()
    {
        RuleFor(x => x)
            .Must(x => x.End - x.Start >= TimeSpan.FromDays(7))
            .WithMessage("Charts can be built for at least one week.");

        RuleFor(x => x.PointsCount)
            .GreaterThanOrEqualTo(5)
            .LessThanOrEqualTo(20);
    }
}
