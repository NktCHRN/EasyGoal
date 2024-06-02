using EasyGoal.Backend.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class IdentityEntityValidationFailedException : EntityValidationFailedException
{
    public IdentityEntityValidationFailedException(string message) : base(message)
    {
    }

    public IdentityEntityValidationFailedException(string message, Exception inner) : base(message, inner)
    {
    }

    public IdentityEntityValidationFailedException(IEnumerable<IdentityError> failures) : base(IdentityFailuresToString(failures)) { }

    public IdentityEntityValidationFailedException(IEnumerable<IdentityError> failures, Exception inner)
        : base(IdentityFailuresToString(failures), inner) { }

    private static string IdentityFailuresToString(IEnumerable<IdentityError> failures)
    {
        return string.Join(Environment.NewLine, failures.Select(f => f.Description));
    }
}
