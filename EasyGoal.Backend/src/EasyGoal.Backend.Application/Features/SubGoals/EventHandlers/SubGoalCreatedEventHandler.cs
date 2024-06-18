using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.DomainEvents;
using EasyGoal.Backend.Domain.Entities.History;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyGoal.Backend.Application.Features.SubGoals.EventHandlers;
public sealed class SubGoalCreatedEventHandler : INotificationHandler<SubGoalCreatedEvent>
{
    private readonly IRepository<HistoricalRecord> _historicalRecordRepository;
    private readonly ILogger<SubGoalCreatedEventHandler> _logger;

    public SubGoalCreatedEventHandler(IRepository<HistoricalRecord> historicalRecordRepository, ILogger<SubGoalCreatedEventHandler> logger)
    {
        _historicalRecordRepository = historicalRecordRepository;
        _logger = logger;
    }

    public Task Handle(SubGoalCreatedEvent notification, CancellationToken cancellationToken)
    {
        var historicalRecord = HistoricalRecord.Create(notification.SubGoalId);
        _historicalRecordRepository.AddAsUnsaved(historicalRecord);

        _logger.LogInformation("SubGoal {SubGoalId} was created. First historical record has been added {HistoricalRecord}.", notification.SubGoalId, historicalRecord);

        return Task.CompletedTask;
    }
}
