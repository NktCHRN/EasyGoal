using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Infrastructure.Database.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<Identity.IdentityApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<FileAttachment> FileAttachments => Set<FileAttachment>();
    public DbSet<Domain.Entities.Task.Task> Tasks => Set<Domain.Entities.Task.Task>();

    public DbSet<Goal> Goals => Set<Goal>();

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
