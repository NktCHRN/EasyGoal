using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class Goal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public string? PictureLocalFileName { get; set; }
    public DateOnly Deadline { get; private set; }
    public Guid UserId { get; set; }

    public int DoneTasks => SubGoals.Sum(g => g.HistoricalRecords[g.HistoricalRecords.Count - 1].CurrentDoneItems);
    public int TotalTasks => SubGoals.Sum(g => g.HistoricalRecords[g.HistoricalRecords.Count - 1].CurrentTotalItems);
    public decimal DoneTasksPercentage => DoneTasks / (decimal)TotalTasks * 100m;

    public string? FileName => string.IsNullOrEmpty(PictureLocalFileName) ? null : $"{Id}{Path.GetExtension(PictureLocalFileName)}";

    public IReadOnlyList<FileAttachment> FileAttachments => _fileAttachments.AsReadOnly();
    private readonly List<FileAttachment> _fileAttachments = [];
    public IReadOnlyList<SubGoal> SubGoals => _subGoals.AsReadOnly();
    private readonly List<SubGoal> _subGoals = [];

    private Goal() { }

    public static Goal Create(string name, DateOnly deadline, Guid userId)
    {
        var goal = new Goal
        {
            Name = name,
            Deadline = deadline,
            UserId = userId
        };

        goal.Validate(userId);

        return goal;
    }

    public void Update(string name, DateOnly deadline, string? description, Guid userId)
    {
        Name = name;
        Deadline = deadline;
        Description = description;

        Validate(userId);
    }

    private void Validate(Guid userId)
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Criterion name must not be empty");
        }

        ValidateOwner(userId);
    }

    public void ValidateOwner(Guid userId)
    {
        if (UserId != userId)
        {
            throw new ForbiddenForUserException("This goal does not belong to current user");
        }
    }

    public void Delete(Guid userId)
    {
        ValidateOwner(userId);

        foreach (var subGoal in SubGoals)
        {
            subGoal.Delete(userId);
        }

        Delete();
    }
}
