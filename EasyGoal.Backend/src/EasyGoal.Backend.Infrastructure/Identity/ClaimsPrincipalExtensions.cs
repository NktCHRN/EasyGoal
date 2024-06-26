﻿using System.Security.Claims;

namespace EasyGoal.Backend.Infrastructure.Identity;
public static class ClaimsPrincipalExtensions
{
    public static Guid? GetId(this ClaimsPrincipal? user)
    {
        if (Guid.TryParse(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid parsed))
            return parsed;
        return null;
    }
}
