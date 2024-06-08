using EasyGoal.Backend.Application.Features.DecisionHelper.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.DecisionHelper.Commands;
public sealed record UpdateDecisionHelperCriteriaCommand : IRequest
{
    public IReadOnlyList<UpdateDecisionHelperCriterionDto> Criteria { get; set; } = [];
}
