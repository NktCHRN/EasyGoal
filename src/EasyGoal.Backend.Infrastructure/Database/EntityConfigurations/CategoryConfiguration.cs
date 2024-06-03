using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(256);
        builder.Property(c => c.ColorHex)
            .HasMaxLength(7);

        builder.HasOne<IdentityApplicationUser>()
            .WithMany(u => u.UserCategories)
            .HasForeignKey(c => c.UserId)
            .IsRequired();
    }
}
