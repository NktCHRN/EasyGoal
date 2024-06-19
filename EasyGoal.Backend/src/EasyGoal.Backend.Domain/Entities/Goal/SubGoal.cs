using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.History;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class SubGoal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public DateOnly Deadline { get; private set; }

    public Guid GoalId { get; private set; }

    public IReadOnlyList<HistoricalRecord> HistoricalRecords => _historicalRecords.AsReadOnly();
    private readonly List<HistoricalRecord> _historicalRecords = [];

    public int DoneTasks => HistoricalRecords.OrderByDescending(h => h.Date).First().CurrentDoneItems;
    public int TotalTasks => HistoricalRecords.OrderByDescending(h => h.Date).First().CurrentTotalItems;

    private SubGoal() { }

    internal static SubGoal Create(string name, DateOnly deadline)
    {
        var subGoal = new SubGoal
        {
            Name = name,
            Deadline = deadline
        };
        subGoal.Validate();

        return subGoal;
    }

    internal void Update(string name, DateOnly deadline)
    {
        Name = name;
        Deadline = deadline;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Sub-goal name must not be empty");
        }
    }
}
