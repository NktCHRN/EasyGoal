namespace EasyGoal.Backend.WebApi.Contracts.Requests.DecisionHelper;

public sealed record ObjectiveEstimates(string Objective, IReadOnlyList<int> Estimates)
{
}
