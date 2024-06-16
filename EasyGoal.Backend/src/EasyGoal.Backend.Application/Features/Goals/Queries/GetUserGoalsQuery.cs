using EasyGoal.Backend.Application.Common;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed record GetUserGoalsQuery(string? SearchText, PaginationParametersDto PaginationParameters) : IRequest<UserGoalsDto>
{
}
