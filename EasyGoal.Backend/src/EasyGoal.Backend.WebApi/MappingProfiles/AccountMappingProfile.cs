using AutoMapper;
using EasyGoal.Backend.Application.Features.Account.Commands;
using EasyGoal.Backend.Application.Features.Account.Dto;
using EasyGoal.Backend.WebApi.Contracts.Requests.Account;
using EasyGoal.Backend.WebApi.Contracts.Responses.Account;

namespace EasyGoal.Backend.WebApi.MappingProfiles;

public sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile() 
    {
        CreateMap<RegisterAccountRequest, RegisterAccountCommand>();
        CreateMap<AccountDto, AccountRegisteredResponse>();

        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<LoginResultDto, LoginResponse>();

        CreateMap<RefreshTokensRequest, RefreshTokensCommand>();
        CreateMap<TokensDto, TokensResponse>();

        CreateMap<RevokeRefreshTokenRequest, RevokeRefreshTokenCommand>();

        CreateMap<UpdateAccountDetailsRequest, UpdateAccountDetailsCommand>();
        CreateMap<AccountDto, AccountResponse>();
    }
}
