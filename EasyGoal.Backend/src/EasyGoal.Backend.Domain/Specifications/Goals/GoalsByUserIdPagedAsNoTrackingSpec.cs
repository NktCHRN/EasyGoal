using Ardalis.Specification;
using EasyGoal.Backend.Domain.Entities.Goal;

namespace EasyGoal.Backend.Domain.Specifications.Goals;
public sealed class GoalsByUserIdPagedAsNoTrackingSpec : Specification<Goal>
{
    public GoalsByUserIdPagedAsNoTrackingSpec(Guid userId, string? searchText, int perPage, int page)
    {
        Query
            .AsNoTracking()
            .Include(g => g.SubGoals)
                .ThenInclude(s => s.HistoricalRecords.OrderByDescending(h => h.Id).Take(1))
            .Where(g => g.UserId == userId);

        if (!string.IsNullOrEmpty(searchText))
        {
            Query.Where(g => g.Name.ToLower().Contains(searchText.ToLower()));
        }

        Query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * perPage)
            .Take(perPage);
    }
}
