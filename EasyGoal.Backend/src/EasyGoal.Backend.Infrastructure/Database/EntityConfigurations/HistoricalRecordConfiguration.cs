using EasyGoal.Backend.Domain.Entities.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class HistoricalRecordConfiguration : IEntityTypeConfiguration<HistoricalRecord>
{
    public void Configure(EntityTypeBuilder<HistoricalRecord> builder)
    {
        builder.HasIndex(h => new { h.SubGoalId, h.Date })
            .IsDescending(false, true)
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");

        builder.Property(h => h.Version)
            .IsRowVersion();
    }
}
