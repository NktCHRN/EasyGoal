namespace EasyGoal.Backend.Application.Features.Calendars.Dto;
public sealed record CalendarTaskDto
{
    public DateTimeOffset Start {  get; set; }
    public DateTimeOffset End { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
