using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.History;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskStatusUpdatedEventHandler : INotificationHandler<TaskStatusUpdatedEvent>
{
    private readonly IRepository<HistoricalRecord> _historicalRecordRepository;
    private readonly ILogger<TaskStatusUpdatedEventHandler> _logger;

    public TaskStatusUpdatedEventHandler(IRepository<HistoricalRecord> historicalRecordRepository, ILogger<TaskStatusUpdatedEventHandler> logger)
    {
        _historicalRecordRepository = historicalRecordRepository;
        _logger = logger;
    }

    public async Task Handle(TaskStatusUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task status {Event} was updated.", notification);

        var initialHistoricalRecord = await _historicalRecordRepository.FirstOrDefaultAsync(
            new NewestHistoricalRecordBySubGoalIdSpec(notification.SubGoalId),
            cancellationToken) ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = initialHistoricalRecord.CreateOrUpdateByCurrentDate();

        if (historicalRecord.Id != initialHistoricalRecord.Id)
        {
            _historicalRecordRepository.AddAsUnsaved(historicalRecord);
        }

        if (notification.IsCompleted)
        {
            historicalRecord.DoItem();
        }
        else
        {
            historicalRecord.UndoItem();
        }

        _logger.LogInformation("Task status {Event} was updated. Historical record has been updated {HistoricalRecord}.", notification, historicalRecord);
    }
}
