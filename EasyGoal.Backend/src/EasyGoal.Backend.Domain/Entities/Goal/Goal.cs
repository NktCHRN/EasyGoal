using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class Goal : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public string? PictureLocalFileName { get; set; }
    public DateOnly Deadline { get; private set; }
    public Guid UserId { get; set; }

    public IReadOnlyList<FileAttachment> FileAttachments => _fileAttachments.AsReadOnly();
    private readonly List<FileAttachment> _fileAttachments = [];
    public IReadOnlyList<SubGoal> SubGoals => _subGoals.AsReadOnly();
    private readonly List<SubGoal> _subGoals = [];
}
