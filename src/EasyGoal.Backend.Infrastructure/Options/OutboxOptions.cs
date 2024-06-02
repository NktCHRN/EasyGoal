namespace EasyGoal.Backend.Infrastructure.Options;
public sealed class OutboxOptions
{
    public int MessagesInBatch { get; set; }
    public int IntervalInSeconds { get; set; }
}
