using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Queries;
public sealed record GetObjectivesRankingQuery : IRequest<ObjectivesRankingDto>
{
    public IReadOnlyList<ObjectiveEstimatesDto> Estimates { get; set; } = null!;
}
