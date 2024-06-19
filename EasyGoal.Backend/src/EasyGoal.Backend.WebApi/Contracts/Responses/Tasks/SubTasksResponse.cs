namespace EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

public sealed record SubTasksResponse(IEnumerable<SubTaskResponse> SubTasks)
{
}
