using EasyGoal.Backend.Domain.Entities.History;

namespace EasyGoal.Backend.Domain.Abstractions;
public interface IHistoryRepository : IRepository<HistoricalRecord>
{
    Task<HistoricalRecord?> GetNewestHistoricalRecordAsync(Guid subGoalId);
}
