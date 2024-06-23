using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.DomainEvents;
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

    public int DoneTasks => SubGoals.Sum(g => g.DoneTasks);
    public int TotalTasks => SubGoals.Sum(g => g.TotalTasks);
    public decimal DoneTasksPercentage => TotalTasks != 0 ? DoneTasks / (decimal)TotalTasks * 100m : 0;
    public decimal TasksPerDay
    {
        get
        {
            var days = (DateTimeOffset.UtcNow - CreatedAt).Days;
            return days != 0 ? TotalTasks / (decimal)days : 0;
        }
    }
    public DateTimeOffset? EndDate => DoneTasks != TotalTasks || DoneTasks == 0 
        ? null 
        : SubGoals.SelectMany(s => s.HistoricalRecords).MaxBy(h => h.DateTime)?.DateTime;

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

    public void Delete(Guid userId)
    {
        ValidateOwner(userId);

        foreach (var subGoal in SubGoals)
        {
            DeleteSubGoalInternal(subGoal);
        }

        base.Delete();
    }

    public SubGoal AddSubGoal(string name, DateOnly deadline, Guid userId)
    {
        ValidateOwner(userId);

        var subGoal = SubGoal.Create(name, deadline);
        _subGoals.Add(subGoal);
        AddDomainEvent(new SubGoalCreatedEvent(subGoal.Id));

        return subGoal;
    }

    public void UpdateSubGoal(Guid id, string name, DateOnly deadline, Guid userId)
    {
        ValidateOwner(userId);
        SubGoal subGoal = FindSubGoal(id);
        subGoal.Update(name, deadline);
    }

    public void DeleteSubGoal(Guid id, Guid userId)
    {
        ValidateOwner(userId);

        var subGoal = FindSubGoal(id);
        DeleteSubGoalInternal(subGoal);
    }

    private SubGoal FindSubGoal(Guid id)
    {
        return SubGoals.FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"Sub-goal with id {id} was not found");
    }

    private void DeleteSubGoalInternal(SubGoal subGoal)
    {
        subGoal.Delete();
        AddDomainEvent(new SubGoalDeletedEvent(subGoal.Id));
    }

    private void Validate(Guid userId)
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Goal name must not be empty");
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
}
