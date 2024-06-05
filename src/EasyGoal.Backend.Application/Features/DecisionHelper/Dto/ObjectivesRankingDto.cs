namespace EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
public sealed record ObjectivesRankingDto
{
    public IReadOnlyList<RankedObjectiveDto> Ranking { get; set; } = [];
}
