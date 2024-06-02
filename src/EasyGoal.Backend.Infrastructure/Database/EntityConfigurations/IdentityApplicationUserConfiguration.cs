using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class IdentityApplicationUserConfiguration : IEntityTypeConfiguration<IdentityApplicationUser>
{
    public void Configure(EntityTypeBuilder<IdentityApplicationUser> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(256);
    }
}
