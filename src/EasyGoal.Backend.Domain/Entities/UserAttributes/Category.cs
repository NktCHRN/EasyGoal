using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.UserAttributes;
public class Category : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string ColorHex { get; private set; } = string.Empty;
    public Guid UserId { get; private set; }
    private Category() { }

    public static Category Create(string name, string colorHex)
    {
        return new Category { Name = name, ColorHex = colorHex };
    }
}
