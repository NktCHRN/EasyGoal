using EasyGoal.Backend.Application.Features.Goals.Commands;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Goals.Validators;
public sealed class UpdateGoalCommandValidator : AbstractValidator<UpdateGoalCommand>
{
    public UpdateGoalCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(c => c.Deadline)
            .GreaterThanOrEqualTo(new DateOnly(1970, 1, 1));

        RuleFor(c => c.Description)
            .MaximumLength(4000);
    }
}
