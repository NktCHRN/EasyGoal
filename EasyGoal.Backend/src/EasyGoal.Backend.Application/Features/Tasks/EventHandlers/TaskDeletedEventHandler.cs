using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.History;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskDeletedEventHandler : INotificationHandler<TaskDeletedEvent>
{
    private readonly IRepository<HistoricalRecord> _historicalRecordRepository;
    private readonly ILogger<TaskDeletedEvent> _logger;

    public TaskDeletedEventHandler(IRepository<HistoricalRecord> historicalRecordRepository, ILogger<TaskDeletedEvent> logger)
    {
        _historicalRecordRepository = historicalRecordRepository;
        _logger = logger;
    }

    public async Task Handle(TaskDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task {Event} was deleted.", notification);

        var initialHistoricalRecord = await _historicalRecordRepository.FirstOrDefaultAsync(
            new NewestHistoricalRecordBySubGoalIdSpec(notification.SubGoalId),
            cancellationToken) ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = initialHistoricalRecord.CreateOrUpdateByCurrentDate();

        if (historicalRecord.Id != initialHistoricalRecord.Id)
        {
            _historicalRecordRepository.AddAsUnsaved(historicalRecord);
        }

        historicalRecord.RemoveItem(notification.IsCompleted);

        _logger.LogInformation("Task {Event} was deleted. Historical record has been updated {HistoricalRecord}.", notification, historicalRecord);
    }
}
