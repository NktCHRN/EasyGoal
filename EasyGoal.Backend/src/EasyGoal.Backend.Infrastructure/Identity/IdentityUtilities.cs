using Microsoft.AspNetCore.Identity;

namespace EasyGoal.Backend.Infrastructure.Identity;
public static class IdentityUtilities
{
    public static string IdentityFailuresToString(IEnumerable<IdentityError> failures)
    {
        return string.Join(Environment.NewLine, failures.Select(f => f.Description));
    }
}
