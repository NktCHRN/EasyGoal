using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class FileInfo : BaseEntity
{
    public string DisplayName { get; private set; } = string.Empty;
    public string BlobReference { get; private set; } = string.Empty;
    public long Size { get; set; }
    public Guid? GoalId { get; private set; }

    private FileInfo() { }

    public static FileInfo Create(string displayName, string blobReference, long size)
    {
        return new FileInfo
        {
            DisplayName = displayName,
            BlobReference = blobReference,
            Size = size
        };
    }
}
