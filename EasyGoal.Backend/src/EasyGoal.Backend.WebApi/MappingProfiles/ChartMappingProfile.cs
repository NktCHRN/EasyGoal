using AutoMapper;
using EasyGoal.Backend.Domain.Utilities;
using EasyGoal.Backend.WebApi.Contracts.Responses.Charts;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class ChartMappingProfile : Profile
{
    public ChartMappingProfile()
    {
        CreateMap<GanttChartData, GanttChartDataResponse>();
        CreateMap<GanttChartLine, GanttChartLineResponse>();
    }
}
