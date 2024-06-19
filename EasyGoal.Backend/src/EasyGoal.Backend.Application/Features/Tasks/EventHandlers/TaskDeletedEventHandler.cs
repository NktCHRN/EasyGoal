using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskDeletedEventHandler : INotificationHandler<TaskDeletedEvent>
{
    private readonly ILogger<TaskDeletedEvent> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly IHistoryRepository _historyRepository;

    public TaskDeletedEventHandler(ILogger<TaskDeletedEvent> logger, TimeProvider timeProvider, IHistoryRepository historyRepository)
    {
        _logger = logger;
        _timeProvider = timeProvider;
        _historyRepository = historyRepository;
    }

    public async Task Handle(TaskDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task {Event} was deleted.", notification);

        var initialHistoricalRecord = await _historyRepository.GetNewestHistoricalRecordAsync(notification.SubGoalId) ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = initialHistoricalRecord.RemoveItem(_timeProvider.GetUtcNow(), notification.IsCompleted);

        _historyRepository.AddAsUnsaved(historicalRecord);

        _logger.LogInformation("Task {Event} was deleted. Historical record has been updated {HistoricalRecord}.", notification, historicalRecord);
    }
}
