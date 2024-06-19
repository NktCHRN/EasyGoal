using EasyGoal.Backend.Application.Features.Tasks.Commands;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Tasks.Validators;
public sealed class UpdateSubTaskCommandValidator : AbstractValidator<UpdateSubTaskCommand>
{
    public UpdateSubTaskCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256);
    }
}
