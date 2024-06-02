namespace EasyGoal.Backend.Infrastructure.Database.SystemEntities;
public class OutboxMessage
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset OccuredOn { get; set; }
    public OutboxMessageStatus Status { get; set; }
    public string? Error { get; set; }
}

public enum OutboxMessageStatus
{
    Created,
    Failed
}
