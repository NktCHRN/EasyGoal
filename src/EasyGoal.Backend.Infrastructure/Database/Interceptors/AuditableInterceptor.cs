using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Application.Abstractions.Presentation;

namespace EasyGoal.Backend.Infrastructure.Database.Interceptors;
public sealed class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _dateTimeProvider;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public AuditableInterceptor(TimeProvider dateTimeProvider, ICurrentApplicationUser currentApplicationUser)
    {
        _dateTimeProvider = dateTimeProvider;
        _currentApplicationUser = currentApplicationUser;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetAuditableProperties(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        SetAuditableProperties(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetAuditableProperties(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        var auditableEntries =
            dbContext
                .ChangeTracker
                .Entries<IAuditableEntity>();

        foreach (var auditableEntry in auditableEntries)
        {
            if (auditableEntry.State is EntityState.Added)
            {
                auditableEntry.Entity.CreatedAt = _dateTimeProvider.GetUtcNow();
                auditableEntry.Entity.CreatedBy = _currentApplicationUser.UserName;
            }
            else if (auditableEntry.State is EntityState.Modified)
            {
                auditableEntry.Entity.ModifiedAt = _dateTimeProvider.GetUtcNow();
                auditableEntry.Entity.ModifiedBy = _currentApplicationUser.UserName;

            }
        }
    }
}
