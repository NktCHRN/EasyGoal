using EasyGoal.Backend.Domain.Entities.Goal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class SubGoalEntityConfiguration : IEntityTypeConfiguration<SubGoal>
{
    public void Configure(EntityTypeBuilder<SubGoal> builder)
    {
        builder.Property(s => s.Name)
            .HasMaxLength(256);
    }
}
