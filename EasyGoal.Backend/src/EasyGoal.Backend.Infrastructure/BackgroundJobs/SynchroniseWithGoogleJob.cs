using Quartz;

namespace EasyGoal.Backend.Infrastructure.BackgroundJobs;
[DisallowConcurrentExecution]
public class SynchroniseWithGoogleJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }
}
