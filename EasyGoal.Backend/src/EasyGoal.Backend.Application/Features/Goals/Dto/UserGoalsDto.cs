namespace EasyGoal.Backend.Application.Features.Goals.Dto;
public sealed record UserGoalsDto(IEnumerable<GoalShortInfoDto> Goals, int TotalCount)
{
}
