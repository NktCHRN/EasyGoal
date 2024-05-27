using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Enums;
using FluentResults;

namespace EasyGoal.Backend.Domain.Entities;
public class SwotPoint : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public SwotPointType PointType { get; private set; }

    public Guid GoalId { get; private set; }
    public Goal Goal { get; private set; } = null!;

    private SwotPoint()
    {

    }

    public static Result<SwotPoint> Create(Goal goal, string description, SwotPointType pointType)
    {

    }
}
