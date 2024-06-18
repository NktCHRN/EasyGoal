using EasyGoal.Backend.Application.Features.SubGoals.Commands;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.SubGoals.Validators;
public sealed class CreateSubGoalCommandValidator : AbstractValidator<CreateSubGoalCommand>
{
    public CreateSubGoalCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(c => c.Deadline)
            .GreaterThanOrEqualTo(new DateOnly(1970, 1, 1));
    }
}
