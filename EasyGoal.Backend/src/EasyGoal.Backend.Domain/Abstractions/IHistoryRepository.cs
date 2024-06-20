using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Entities.History;

namespace EasyGoal.Backend.Domain.Abstractions;
public interface IHistoryRepository : IRepository<HistoricalRecord>
{
    Task<HistoricalRecord?> GetNewestHistoricalRecordAsync(Guid subGoalId);
    Task<Goal?> GetGoalWithSubGoalsStartDateEndDateAsync(Guid goalId);
    Task<Goal?> GetGoalWithSubGoalsAndHistoricalRecordsByDatesAsync(Guid goalId, DateTimeOffset start, DateTimeOffset end);
}
