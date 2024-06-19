using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskStatusUpdatedEventHandler : INotificationHandler<TaskStatusUpdatedEvent>
{
    private readonly ILogger<TaskStatusUpdatedEventHandler> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly IHistoryRepository _historyRepository;

    public TaskStatusUpdatedEventHandler(ILogger<TaskStatusUpdatedEventHandler> logger, TimeProvider timeProvider, IHistoryRepository historyRepository)
    {
        _logger = logger;
        _timeProvider = timeProvider;
        _historyRepository = historyRepository;
    }

    public async Task Handle(TaskStatusUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task status {Event} was updated.", notification);

        var initialHistoricalRecord = await _historyRepository.GetNewestHistoricalRecordAsync(notification.SubGoalId) 
            ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = notification.IsCompleted 
            ? initialHistoricalRecord.DoItem(_timeProvider.GetUtcNow()) 
            : initialHistoricalRecord.UndoItem(_timeProvider.GetUtcNow());

        _historyRepository.AddAsUnsaved(historicalRecord);

        _logger.LogInformation("Task status {Event} was updated. Historical record has been updated {HistoricalRecord}.", notification, historicalRecord);
    }
}
