using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class IdentityApplicationUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(256);

        builder.Property(e => e.AvatarLocalFileName)
            .HasMaxLength(128);
    }
}
