using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;

namespace EasyGoal.Backend.Domain.Entities.Goal;
public class Goal : BaseAuditableEntity
{
    public Guid UserId { get; set; }

    public IReadOnlyList<FileAttachment> FileAttachments => _fileAttachments.AsReadOnly();
    private readonly List<FileAttachment> _fileAttachments = [];
}
