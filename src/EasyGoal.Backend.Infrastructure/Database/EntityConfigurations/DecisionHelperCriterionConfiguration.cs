using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class DecisionHelperCriterionConfiguration : IEntityTypeConfiguration<DecisionHelperCriterion>
{
    public void Configure(EntityTypeBuilder<DecisionHelperCriterion> builder)
    {
        builder.Property(d => d.Name)
            .HasMaxLength(32);

        builder.HasOne<IdentityApplicationUser>()
            .WithMany(u => u.DecisionHelperCriteria)
            .HasForeignKey(c => c.UserId)
            .IsRequired();
    }
}
