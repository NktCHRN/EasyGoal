﻿using EasyGoal.Backend.Domain.Entities.Goal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(256);

        builder.HasOne(t => t.SubGoal)
            .WithMany()
            .HasForeignKey(t => t.SubGoalId);

        builder.HasIndex(t => new { t.StartTime, t.EndTime })
            .HasFilter("\"IsDeleted\" = false");
    }
}
