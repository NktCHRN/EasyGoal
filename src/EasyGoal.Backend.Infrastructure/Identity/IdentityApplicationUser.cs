using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.UserAttributes;
using Microsoft.AspNetCore.Identity;

namespace EasyGoal.Backend.Infrastructure.Identity;
public class IdentityApplicationUser : IdentityUser<Guid>, IAuditableEntity, ISoftDeletableEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }

    public IList<RefreshToken> RefreshTokens { get; set; } = [];
    public IList<Category> UserCategories { get; set; } = [];
}
