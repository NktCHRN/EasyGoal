using EasyGoal.Backend.Domain.Abstractions.Utilities;
using EasyGoal.Backend.Domain.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace EasyGoal.Backend.Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IMCDAMethod, VikorMCDAMethod>()
            .AddSingleton<IDecisionHelper, DecisionHelper>()
            .AddSingleton<IGanttChartDataProvider, GanttChartDataProvider>();
    }
}
