using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Infrastructure.Database.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<Identity.IdentityUser, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyGlobalBaseEntityConfiguration();
        modelBuilder.ApplyGlobalEnumsConfiguration();
        modelBuilder.ApplyGlobalAuditableConfiguration();
        modelBuilder.ApplyGlobalQueryFilter<ISoftDeletableEntity>(s => !s.IsDeleted);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);
    }
}
