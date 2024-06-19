namespace EasyGoal.Backend.WebApi.Contracts.Responses.Tasks;

public sealed record SubTaskResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
