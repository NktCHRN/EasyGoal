using EasyGoal.Backend.Application.Common;
using EasyGoal.Backend.Application.Features.Goals.Queries;
using FluentValidation;

namespace EasyGoal.Backend.Application.Features.Goals.Validators;
public class GetUserGoalsQueryValidator : AbstractValidator<GetUserGoalsQuery>
{
    private readonly IValidator<PaginationParametersDto> _paginationParametersDtoValidator;

    public GetUserGoalsQueryValidator(IValidator<PaginationParametersDto> paginationParametersDtoValidator)
    {
        _paginationParametersDtoValidator = paginationParametersDtoValidator;

        RuleFor(q => q.SearchText)
            .MaximumLength(256);

        RuleFor(q => q.PaginationParameters)
            .SetValidator(_paginationParametersDtoValidator);
    }
}
