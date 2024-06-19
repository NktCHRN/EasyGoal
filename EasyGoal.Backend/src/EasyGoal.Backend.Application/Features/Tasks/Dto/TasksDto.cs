namespace EasyGoal.Backend.Application.Features.Tasks.Dto;
public sealed record TasksDto(IReadOnlyList<TaskShortInfoDto> Tasks)
{
}
