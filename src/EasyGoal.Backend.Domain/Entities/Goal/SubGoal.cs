using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class SubGoal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset Deadline { get; private set; }

    public IReadOnlyList<HistoryRecord> HistoryRecords => _historyRecords.AsReadOnly();
    private readonly List<HistoryRecord> _historyRecords = [];
    public IReadOnlyList<Task.Task> Tasks => _tasks.AsReadOnly();
    private readonly List<Task.Task> _tasks = [];
}
