using AutoMapper;
using EasyGoal.Backend.Application.Features.Charts.Dto;
using EasyGoal.Backend.Domain.Utilities;

namespace EasyGoal.Backend.Application.Features.Charts.MappingProfiles;
public sealed class ChartMappingProfile : Profile
{
    public ChartMappingProfile()
    {
        CreateMap<BurnUpChartData, BurnUpChartDataDto>();
        CreateMap<BurnUpChartItem, BurnUpChartItemDto>();
    }
}
