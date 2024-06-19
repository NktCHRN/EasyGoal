using EasyGoal.Backend.Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Infrastructure.Database.EntityConfigurations;
public sealed class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
{
    public void Configure(EntityTypeBuilder<SubTask> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(256);

        builder.HasOne<Task>()
            .WithMany(t => t.SubTasks)
            .HasForeignKey(t => t.TaskId);
    }
}
