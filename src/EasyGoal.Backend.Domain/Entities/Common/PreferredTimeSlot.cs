using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class PreferredTimeSlot : BaseEntity
{
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }

    public static PreferredTimeSlot Create(TimeOnly startTime, TimeOnly endTime)
    {
        if (startTime >= endTime)
        {
            throw new EntityValidationFailedException("Start time cannot be later then or same as end time");
        }

        return new PreferredTimeSlot { StartTime = startTime, EndTime = endTime };
    }

    public bool Overlaps(PreferredTimeSlot another)
    {
        return !(EndTime <= another.StartTime || StartTime >= another.EndTime);
    }

    public override string ToString()
    {
        return $"{StartTime.ToShortTimeString()}-{EndTime.ToShortTimeString()}";
    }
}
