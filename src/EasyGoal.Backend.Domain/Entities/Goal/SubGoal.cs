using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class SubGoal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset Deadline { get; private set; }

    public IReadOnlyList<HistoricalRecord> HistoricalRecords => _historicalRecords.AsReadOnly();
    private readonly List<HistoricalRecord> _historicalRecords = [];
    public IReadOnlyList<Task.Task> Tasks => _tasks.AsReadOnly();
    private readonly List<Task.Task> _tasks = [];
}
