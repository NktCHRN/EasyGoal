using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class GoalEntityConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.Property(g => g.Name)
            .HasMaxLength(256);
        builder.Property(g => g.PictureLocalFileName)
            .HasMaxLength(256);

        builder.HasOne<IdentityApplicationUser>()
            .WithMany()
            .HasForeignKey(f => f.UserId);

        builder.HasIndex(g => new { g.CreatedAt })
            .IsDescending(true);
    }
}
