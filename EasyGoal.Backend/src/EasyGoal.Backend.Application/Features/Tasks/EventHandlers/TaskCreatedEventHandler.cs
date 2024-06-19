using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;
using EasyGoal.Backend.Domain.Specifications.History;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.Tasks.EventHandlers;
public sealed class TaskCreatedEventHandler : INotificationHandler<TaskCreatedEvent>
{
    private readonly IRepository<HistoricalRecord> _historicalRecordRepository;
    private readonly ILogger<TaskCreatedEventHandler> _logger;

    public TaskCreatedEventHandler(IRepository<HistoricalRecord> historicalRecordRepository, ILogger<TaskCreatedEventHandler> logger)
    {
        _historicalRecordRepository = historicalRecordRepository;
        _logger = logger;
    }

    public async Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
    {
        var initialHistoricalRecord = await _historicalRecordRepository.FirstOrDefaultAsync(
            new NewestHistoricalRecordBySubGoalIdSpec(notification.SubGoalId), 
            cancellationToken) ?? throw new EntityNotFoundException($"No historical records were found for sub goal {notification.SubGoalId}");

        var historicalRecord = initialHistoricalRecord.CreateOrUpdateByCurrentDate();

        if (historicalRecord.Id != initialHistoricalRecord.Id)
        {
            _historicalRecordRepository.AddAsUnsaved(historicalRecord);
        }

        historicalRecord.AddItem();
    }
}
