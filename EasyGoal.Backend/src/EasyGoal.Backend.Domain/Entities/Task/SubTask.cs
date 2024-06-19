using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Task;
public class SubTask : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    public Guid TaskId { get; private set; }

    private SubTask() { }

    internal static SubTask Create(string name)
    {
        var subTask = new SubTask() { Name = name };
        subTask.Validate();
        return subTask;
    }

    internal void Update(string name)
    {
        Name = name;
        Validate();
    }

    internal void UpdateStatus(bool isCompleted)
    {
        IsCompleted = isCompleted;
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Sub-task name must not be empty");
        }
    }
}
