namespace EasyGoal.Backend.WebApi.Contracts.Responses.DecisionHelper;

public sealed record RankedObjectiveResponse(string Objective, bool IsRecommended, double Points)
{
}
