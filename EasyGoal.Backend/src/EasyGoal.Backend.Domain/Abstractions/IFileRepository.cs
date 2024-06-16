using EasyGoal.Backend.Domain.Common;

namespace EasyGoal.Backend.Domain.Abstractions;
public interface IFileRepository
{
    Task UploadGoalPictureAsync(FileData file);
    Task<FileData?> DownloadGoalPictureAsync(Guid goalId);
    Task<bool> GoalPictureExistsAsync(Guid goalId);

    Task UploadGoalFileAsync(Guid goalId, FileData file);
    Task<FileData?> DownloadGoalFileAsync(Guid goalId, string fileName);
    Task<bool> GoalFileExistsAsync(Guid goalId, string fileName);
}
