﻿using EasyGoal.Backend.Infrastructure.Extensions;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    //public DbSet<Goal> Goals => Set<Goal>();
    //public DbSet<SubGoal> SubGoals => Set<SubGoal>();

    // Add other entities!!!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyGlobalEnumsConfiguration();
        modelBuilder.ApplyGlobalAuditableConfiguration();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(IInfrastructureAssemblyMarker))!);
    }
}