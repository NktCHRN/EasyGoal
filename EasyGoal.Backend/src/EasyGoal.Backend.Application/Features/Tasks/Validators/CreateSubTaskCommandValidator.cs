using EasyGoal.Backend.Application.Features.Tasks.Commands;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Tasks.Validators;
public sealed class CreateSubTaskCommandValidator : AbstractValidator<CreateSubTaskCommand>
{
    public CreateSubTaskCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256);
    }
}
