using EasyGoal.Backend.Domain.Entities.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class HistoricalRecordConfiguration : IEntityTypeConfiguration<HistoricalRecord>
{
    public void Configure(EntityTypeBuilder<HistoricalRecord> builder)
    {
        builder.HasIndex(h => new { h.SubGoalId, h.DateTime })
            .IsDescending(false, true)
            .HasFilter("\"IsDeleted\" = false");
    }
}
