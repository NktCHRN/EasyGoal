using EasyGoal.Backend.Domain.Abstractions.Entities;
using EasyGoal.Backend.Domain.Entities.UserAttributes;
using EasyGoal.Backend.Domain.Exceptions;

namespace EasyGoal.Backend.Domain.Entities.Common;
public class PreferredDaysOfWeekRange : BaseEntity
{
    public IReadOnlyList<PreferredDayOfWeek> PreferredDaysOfWeek => _preferredDaysOfWeek;
    private readonly List<PreferredDayOfWeek> _preferredDaysOfWeek = [];

    public Category? Category { get; private set; }

    private PreferredDaysOfWeekRange() { }

    public static PreferredDaysOfWeekRange Create(IEnumerable<PreferredDayOfWeek> preferredDaysOfWeek)
    {
        var range = new PreferredDaysOfWeekRange();
        range._preferredDaysOfWeek.AddRange(preferredDaysOfWeek);

        range.ValidateDuplicates();

        return range;
    }

    private void ValidateDuplicates()
    {
        if (PreferredDaysOfWeek.Count != PreferredDaysOfWeek.DistinctBy(d => d.DayOfWeek).Count())
        {
            throw new EntityValidationFailedException("Some preferred days of week are duplicate");
        }
    }
}
