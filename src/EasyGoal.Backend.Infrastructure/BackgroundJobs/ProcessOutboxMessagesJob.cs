using EasyGoal.Backend.Domain.Abstractions.DomainEvents;
using EasyGoal.Backend.Infrastructure.Database;
using EasyGoal.Backend.Infrastructure.Database.SystemEntities;
using EasyGoal.Backend.Infrastructure.Options;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using System.Text.Json;

namespace EasyGoal.Backend.Infrastructure.BackgroundJobs;
[DisallowConcurrentExecution]
public sealed class ProcessOutboxMessagesJob : IJob
{
    private readonly ApplicationDbContext _dbContext;
    private readonly JsonSerializerOptions _jsonSerializerOptions;  
    private readonly IPublisher _publisher;
    private readonly OutboxOptions _outboxOptions;
    private readonly ILogger<ProcessOutboxMessagesJob> _logger;

    public ProcessOutboxMessagesJob(ApplicationDbContext dbContext, IOptions<JsonSerializerOptions> jsonSerializerOptions, IPublisher publisher, IOptions<OutboxOptions> outboxOptions, ILogger<ProcessOutboxMessagesJob> logger)
    {
        _dbContext = dbContext;
        _jsonSerializerOptions = jsonSerializerOptions.Value;
        _publisher = publisher;
        _outboxOptions = outboxOptions.Value;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var transaction = await _dbContext.Database.BeginTransactionAsync(context.CancellationToken);

        var messages = await _dbContext.OutboxMessages
            .FromSql($@"
                SELECT *
                FROM ""{nameof(_dbContext.OutboxMessages)}""
                WHERE ""{nameof(OutboxMessage.Status)}"" = '{nameof(OutboxMessageStatus.Created)}'
                ORDER BY ""{nameof(OutboxMessage.Id)}"" ASC
                FOR UPDATE")
            .Take(_outboxOptions.MessagesInBatch)
            .ToListAsync(context.CancellationToken);

        foreach (var message in messages)
        {
            try
            {
                var domainEvent = (BaseEvent)JsonSerializer.Deserialize(message.Content, Type.GetType(message.Type!)!, _jsonSerializerOptions)!;

                await _publisher.Publish(domainEvent, context.CancellationToken);

                _dbContext.Remove(message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while processing {Type} event (Id: {Id}). Exception: {exception}", message.Type, message.Id, ex);
                _dbContext.ChangeTracker.Clear();

                message.Status = OutboxMessageStatus.Failed;
                message.Error = JsonSerializer.Serialize(ex);
            }
            finally
            {
                await _dbContext.SaveChangesAsync(context.CancellationToken);
            }
        }

        await transaction.CommitAsync(context.CancellationToken);
    }
}
