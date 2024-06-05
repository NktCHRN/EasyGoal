using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Enums;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.DecisionHelper;
public sealed class DecisionHelperCriterion : BaseEntity
{
    public int Order { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Weight { get; private set; }
    public DecisionHelperCriterionType Type { get; private set; }
    public Guid UserId { get; set; }

    private const int MaxNameLength = 20;

    private DecisionHelperCriterion() { }

    public static DecisionHelperCriterion Create(int order, string name, decimal weight, DecisionHelperCriterionType type)
    {
        name = name?.Trim() ?? string.Empty;

        var helper = new DecisionHelperCriterion() { Order = order, Name = name, Weight = weight, Type = type };

        helper.Validate();

        return helper;
    }

    public void Update(int order, string name, decimal weight, DecisionHelperCriterionType type)
    {
        Order = order;
        Name = name?.Trim() ?? string.Empty;
        Weight = weight;
        Type = type;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new EntityValidationFailedException("Criterion name must not be empty");
        }
        if (Name.Length > MaxNameLength)
        {
            throw new EntityValidationFailedException($"Max criterion name length is {MaxNameLength}");
        }
    }

    public static void ValidateList(IEnumerable<DecisionHelperCriterion> decisionHelperCriteria)
    {
        if (decisionHelperCriteria.Sum(d => d.Weight) != 1m)
        {
            throw new EntityValidationFailedException("Sum of weights of all decision helper criteria must be 1.");
        }

        if (!decisionHelperCriteria.Select(d => d.Order).Distinct().Order()
            .SequenceEqual(Enumerable.Range(1, decisionHelperCriteria.Count())))
        {
            throw new EntityValidationFailedException("Order is incorrect.");
        }
    }

    public static IList<DecisionHelperCriterion> DefaultCriteria =>
    [
        Create(1, "Value", 0.2m, DecisionHelperCriterionType.Ascending),
        Create(2, "Attainability", 0.2m, DecisionHelperCriterionType.Ascending),
        Create(3, "Difficulty", 0.2m, DecisionHelperCriterionType.Descending),
        Create(4, "Urgency", 0.2m, DecisionHelperCriterionType.Ascending),
        Create(5, "Enjoyment", 0.2m, DecisionHelperCriterionType.Ascending),
    ];
}
