namespace EasyGoal.Backend.WebApi.Contracts.Requests.Tasks;

public sealed record CreateTaskRequest(string Name, DateTimeOffset? StartTime, DateTimeOffset? EndTime)
{
}
