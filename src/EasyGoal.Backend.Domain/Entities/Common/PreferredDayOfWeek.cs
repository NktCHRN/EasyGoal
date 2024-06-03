using EasyGoal.Backend.Domain.Abstractions.Entities;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class PreferredDayOfWeek : BaseEntity
{
    public DayOfWeek DayOfWeek { get; private set; }

    private PreferredDayOfWeek() { }

    public static PreferredDayOfWeek Create(DayOfWeek dayOfWeek)
    {
        return new PreferredDayOfWeek() { DayOfWeek = dayOfWeek };
    }

    public override string ToString()
    {
        return DayOfWeek.ToString();
    }
}
