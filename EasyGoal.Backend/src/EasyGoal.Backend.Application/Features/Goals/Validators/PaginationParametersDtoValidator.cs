using EasyGoal.Backend.Application.Common;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Goals.Validators;
public class PaginationParametersDtoValidator : AbstractValidator<PaginationParametersDto>
{
    public PaginationParametersDtoValidator()
    {
        RuleFor(p => p.PerPage)
            .GreaterThan(0)
            .LessThanOrEqualTo(100);

        RuleFor(p => p.Page)
            .GreaterThan(0);
    }
}
