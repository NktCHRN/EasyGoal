namespace EasyGoal.Backend.WebApi.Contracts.Responses.Calendar;

public sealed record CalendarTaskResponse
{
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
