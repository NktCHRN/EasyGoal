using EasyGoal.Backend.Domain.Entities.Common;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class FileInfoConfiguration : IEntityTypeConfiguration<FileAttachment>
{
    public void Configure(EntityTypeBuilder<FileAttachment> builder)
    {
        builder.Property(p => p.DisplayName)
            .HasMaxLength(256);
        builder.Property(p => p.BlobReference)
            .HasMaxLength(256);
    }
}
