using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class PreferredTimeSlotsRange : BaseEntity
{
    public IReadOnlyList<PreferredTimeSlot> PreferredTime => _preferredTime;
    private readonly List<PreferredTimeSlot> _preferredTime = [];

    public Category? Category { get; private set; }

    private PreferredTimeSlotsRange() { }

    public static PreferredTimeSlotsRange Create(IEnumerable<PreferredTimeSlot> preferredTimeSlots)
    {
        var range = new PreferredTimeSlotsRange();
        range._preferredTime.AddRange(preferredTimeSlots);

        range.ValidateOverlapping();

        return range;
    }

    private void ValidateOverlapping()
    {
        foreach (var preferredTimeSlot in PreferredTime)
        {
            foreach (var anotherPreferredTimeSlot in PreferredTime)
            {
                if (preferredTimeSlot == anotherPreferredTimeSlot)
                {
                    continue;
                }

                if (preferredTimeSlot.Overlaps(anotherPreferredTimeSlot))
                {
                    throw new EntityValidationFailedException($"Time slots {preferredTimeSlot} and {anotherPreferredTimeSlot} are overlapping");
                }
            }
        }
    }
}
