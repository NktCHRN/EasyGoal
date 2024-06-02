using EasyGoal.Backend.Infrastructure.Database.SystemEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.Property(o => o.Type)
            .HasMaxLength(512);
    }
}
