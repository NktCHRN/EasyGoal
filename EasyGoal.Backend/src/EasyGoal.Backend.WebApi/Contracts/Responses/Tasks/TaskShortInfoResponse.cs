namespace EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

public sealed record TaskShortInfoResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public DateTimeOffset? StartTime { get; init; }
    public DateTimeOffset? EndTime { get; init; }
    public int DoneSubTasks { get; init; }
    public int TotalSubTasks { get; init; }
}
