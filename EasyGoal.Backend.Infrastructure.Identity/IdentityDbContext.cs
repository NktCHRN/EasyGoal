using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EasyGoal.Backend.Infrastructure.Extensions;
using EasyGoal.Backend.Infrastructure.Identity.Entities;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : IdentityDbContext<IdentityApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(IInfrastructureIdentityAssemblyMarker))!);
        modelBuilder.ApplyGlobalEnumsConfiguration();
    }
}
