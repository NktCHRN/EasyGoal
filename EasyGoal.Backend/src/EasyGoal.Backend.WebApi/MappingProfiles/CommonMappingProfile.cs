using AutoMapper;
using EasyGoal.Backend.Application.Common;
using EasyGoal.Backend.WebApi.Contracts.Requests.Common;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class CommonMappingProfile : Profile
{
    public CommonMappingProfile()
    {
        CreateMap<PaginationParametersRequest, PaginationParametersDto>();
    }
}
