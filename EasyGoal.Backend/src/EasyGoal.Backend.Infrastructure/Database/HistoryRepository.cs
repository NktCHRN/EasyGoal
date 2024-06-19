using EasyGoal.Backend.Domain.Abstractions;
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
}
