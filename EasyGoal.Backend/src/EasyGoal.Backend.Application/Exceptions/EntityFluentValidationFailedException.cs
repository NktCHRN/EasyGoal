using EasyGoal.Backend.Domain.Exceptions;
using FluentValidation.Results;

namespace EasyGoal.Backend.Application.Exceptions;
[Serializable]
public sealed class EntityFluentValidationFailedException : EntityValidationFailedException
{
    public EntityFluentValidationFailedException(string message) : base(message)
    {
    }

    public EntityFluentValidationFailedException(string message, Exception inner) : base(message, inner)
    {
    }

    public EntityFluentValidationFailedException(IEnumerable<ValidationFailure> failures) : base(FluentValidationFailuresToString(failures)) { }

    public EntityFluentValidationFailedException(IEnumerable<ValidationFailure> failures, Exception inner)
        : base(FluentValidationFailuresToString(failures), inner) { }

    private static string FluentValidationFailuresToString(IEnumerable<ValidationFailure> failures)
    {
        return string.Join(Environment.NewLine, failures.Select(f => f.ErrorMessage));
    }
}
