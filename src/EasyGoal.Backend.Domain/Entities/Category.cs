using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities;
public class Category : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string ColorHex { get; private set; } = string.Empty;
}
