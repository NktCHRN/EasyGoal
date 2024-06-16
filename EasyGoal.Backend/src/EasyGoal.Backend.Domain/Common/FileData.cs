namespace EasyGoal.Backend.Domain.Common;
public sealed class FileData
{
    public string Name { get; set; } = string.Empty;
    public BinaryData Data { get; set; } = null!;
    public string ContentType { get; set; } = string.Empty;
}
