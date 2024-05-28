using EasyGoal.Backend.Domain;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<SubGoal> SubGoals => Set<SubGoal>();

    // Add other entities!!!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(IDomainAssemblyMarker))!);
        modelBuilder.ApplyGlobalEnumsConfiguration();
    }
}
