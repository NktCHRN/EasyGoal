using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.Common;

namespace EasyGoal.Backend.Domain.Entities.UserAttributes;
public class Category : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string ColorHex { get; private set; } = string.Empty;
    public Guid UserId { get; private set; }

    public Guid PreferredDaysOfWeekRangeId { get; private set; }
    public PreferredDaysOfWeekRange PreferredDaysOfWeekRange { get; private set; } = null!;
    public Guid PreferredTimeSlotsRangeId { get; private set; }
    public PreferredTimeSlotsRange PreferredTimeSlotsRange { get; private set; } = null!;

    private Category() { }

    public static Category Create(string name, string colorHex)
    {
        return Create(name, colorHex, [], []);
    }

    public static Category Create(string name, string colorHex, IEnumerable<PreferredDayOfWeek> preferredDaysOfWeek, IEnumerable<PreferredTimeSlot> preferredTimeSlots)
    {
        var category = new Category
        {
            Name = name,
            ColorHex = colorHex,
            PreferredDaysOfWeekRange = PreferredDaysOfWeekRange.Create(preferredDaysOfWeek),
            PreferredTimeSlotsRange = PreferredTimeSlotsRange.Create(preferredTimeSlots)
        };

        return category;
    }
}
