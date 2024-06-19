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
    private readonly TimeProvider _timeProvider;

    public SubGoalCreatedEventHandler(IRepository<HistoricalRecord> historicalRecordRepository, ILogger<SubGoalCreatedEventHandler> logger, TimeProvider timeProvider)
    {
        _historicalRecordRepository = historicalRecordRepository;
        _logger = logger;
        _timeProvider = timeProvider;
    }

    public Task Handle(SubGoalCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SubGoal {Event} was created.", notification);

        var historicalRecord = HistoricalRecord.Create(_timeProvider.GetUtcNow(), notification.SubGoalId);
        _historicalRecordRepository.AddAsUnsaved(historicalRecord);

        _logger.LogInformation("SubGoal {Event} was created. First historical record has been added {HistoricalRecord}.", notification, historicalRecord);

        return Task.CompletedTask;
    }
}
