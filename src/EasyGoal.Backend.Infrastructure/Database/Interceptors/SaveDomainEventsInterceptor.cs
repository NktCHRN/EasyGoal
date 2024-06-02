using EasyGoal.Backend.Domain.Abstractions.DomainEvents;
using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Infrastructure.Database.SystemEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyGoal.Backend.Infrastructure.Database.Interceptors;
public sealed class SaveDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _dateTimeProvider;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public SaveDomainEventsInterceptor(TimeProvider dateTimeProvider, IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jsonSerializerOptions = jsonSerializerOptions.Value;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SaveDomainEventsAsync(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await SaveDomainEventsAsync(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task SaveDomainEventsAsync(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        var domainEvents = new List<BaseEvent>();
        foreach (var entity in dbContext.ChangeTracker.Entries<BaseEntity>().Select(e => e.Entity))
        {
            domainEvents.AddRange(entity.DomainEvents);
            entity.ClearDomainEvents();
        }

        foreach (var domainEvent in domainEvents)
        {
            await dbContext.AddAsync(new OutboxMessage
            {
                Type = domainEvent.GetType().FullName!,
                Status = OutboxMessageStatus.Created,
                OccuredOn = _dateTimeProvider.GetUtcNow(),
                Content = JsonSerializer.Serialize(domainEvent, _jsonSerializerOptions)
            });
        }
    }
}
