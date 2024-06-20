using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Entities.History;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class HistoryRepository : GenericRepository<HistoricalRecord>, IHistoryRepository
{
    public HistoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<HistoricalRecord?> GetNewestHistoricalRecordAsync(Guid subGoalId)
    {
        return await ApplicationDbContext
            .HistoricalRecords
            .FromSql($@"
                SELECT *
                FROM ""HistoricalRecords""
                WHERE ""SubGoalId"" = {subGoalId}
                ORDER BY ""Id"" DESC
                FOR UPDATE")
            .FirstOrDefaultAsync();
    }

    public async Task<Goal?> GetGoalWithSubGoalsStartDateEndDateAsync(Guid goalId)
    {
        return await ApplicationDbContext
            .Goals
            .AsNoTracking()
            .Include(g => g.SubGoals)
                .ThenInclude(s => s.HistoricalRecords.Where(
                    h => h.DateTime == s.HistoricalRecords.Min(h => h.DateTime) 
                    || h.DateTime == s.HistoricalRecords.Max(h => h.DateTime)))
            .FirstOrDefaultAsync(g => g.Id == goalId);
    }

    public async Task<Goal?> GetGoalWithSubGoalsAndHistoricalRecordsByDatesAsync(Guid goalId, DateTimeOffset start, DateTimeOffset end)
    {
        return await ApplicationDbContext
            .Goals
            .AsNoTracking()
            .Include(g => g.SubGoals)
                .ThenInclude(s => s.HistoricalRecords.Where(
                    h => (h.DateTime >= start && h.DateTime <= end) 
                        || (h.DateTime == s.HistoricalRecords.Where(sh => sh.DateTime < start).Max(hs => hs.DateTime))
                        || (h.DateTime == s.HistoricalRecords.Where(sh => sh.DateTime > end).Min(hs => hs.DateTime)))
                .OrderBy(h => h.DateTime))
            .FirstOrDefaultAsync(g => g.Id == goalId);
    }
}
