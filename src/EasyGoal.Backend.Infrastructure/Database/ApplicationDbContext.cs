using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Entities.DecisionHelper;
using EasyGoal.Backend.Infrastructure.Database.Extensions;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class ApplicationDbContext : IdentityDbContext<IdentityApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<FileAttachment> FileAttachments => Set<FileAttachment>();
    public DbSet<Domain.Entities.Task.Task> Tasks => Set<Domain.Entities.Task.Task>();

    public DbSet<Goal> Goals => Set<Goal>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<DecisionHelperCriterion> DecisionHelperCriteria => Set<DecisionHelperCriterion>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

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
