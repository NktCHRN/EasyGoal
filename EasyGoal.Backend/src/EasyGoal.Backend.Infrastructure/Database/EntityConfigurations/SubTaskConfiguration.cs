using EasyGoal.Backend.Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
{
    public void Configure(EntityTypeBuilder<SubTask> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(256);
    }
}
