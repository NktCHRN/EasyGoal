﻿using EasyGoal.Backend.Application.Features.Tasks.Commands;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Tasks.Validators;
public sealed class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(c => c.StartTime)
            .GreaterThanOrEqualTo(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        RuleFor(c => c.EndTime)
            .GreaterThanOrEqualTo(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

        RuleFor(c => c.Notes)
            .MaximumLength(2000);
    }
}
