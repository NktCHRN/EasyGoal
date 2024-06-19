namespace EasyGoal.Backend.WebApi.Contracts.Requests.Tasks;

public sealed record UpdateTaskRequest(string Name, DateTimeOffset? StartTime, DateTimeOffset? EndTime, string? Notes)
{
}
