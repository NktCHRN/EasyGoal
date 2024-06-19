namespace EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

public sealed record TasksResponse(IReadOnlyList<TaskShortInfoResponse> Tasks)
{
}
