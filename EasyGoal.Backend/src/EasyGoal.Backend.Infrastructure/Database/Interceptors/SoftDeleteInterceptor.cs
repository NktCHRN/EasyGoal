using EasyGoal.Backend.Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Database.Interceptors;
public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ChangeDeletedEntitiesState(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        ChangeDeletedEntitiesState(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void ChangeDeletedEntitiesState(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        var entries =
            dbContext
                .ChangeTracker
                .Entries<ISoftDeletableEntity>()
                .Where(e => e.State == EntityState.Deleted);

        foreach (var softDeletableEntity in entries)
        {
            softDeletableEntity.State = EntityState.Modified;
            softDeletableEntity.Entity.IsDeleted = true;
        }
    }
}
