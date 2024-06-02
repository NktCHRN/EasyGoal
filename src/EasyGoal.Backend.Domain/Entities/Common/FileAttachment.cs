using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class FileAttachment : BaseEntity
{
    public string DisplayName { get; private set; } = string.Empty;
    public string BlobReference { get; private set; } = string.Empty;
    public long Size { get; set; }
    public Guid? GoalId { get; private set; }
    public Goal.Goal? Goal { get; private set; }
    public Guid? UserId { get; private set; }

    private FileAttachment() { }

    public static FileAttachment Create(string displayName, string blobReference, long size)
    {
        return new FileAttachment
        {
            DisplayName = displayName,
            BlobReference = blobReference,
            Size = size
        };
    }
}
