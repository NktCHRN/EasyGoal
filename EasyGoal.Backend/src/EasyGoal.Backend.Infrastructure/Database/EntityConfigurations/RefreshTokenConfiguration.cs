using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Property(e => e.Token)
            .HasMaxLength(256);

        builder.ToTable("RefreshTokens");

        builder.HasIndex(r => new { r.UserId, r.Token })
            .HasFilter("\"IsDeleted\" = false");
    }
}
