using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskCreatedEventHandler : INotificationHandler<TaskCreatedEvent>
{
    private readonly ILogger<TaskCreatedEventHandler> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly IHistoryRepository _historyRepository;

    public TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger, TimeProvider timeProvider, IHistoryRepository historyRepository)
    {
        _logger = logger;
        _timeProvider = timeProvider;
        _historyRepository = historyRepository;
    }

    public async Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task {Event} was created.", notification);

        var initialHistoricalRecord = await _historyRepository.GetNewestHistoricalRecordAsync(notification.SubGoalId) ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = initialHistoricalRecord.AddItem(_timeProvider.GetUtcNow());

        _historyRepository.AddAsUnsaved(historicalRecord);

        _logger.LogInformation("Task {Event} was created. Historical record has been updated {HistoricalRecord}.", notification, historicalRecord);
    }
}
