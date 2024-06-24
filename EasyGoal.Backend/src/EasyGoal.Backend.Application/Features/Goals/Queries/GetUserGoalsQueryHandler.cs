using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Goals.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Entities.Goal;
using EasyGoal.Backend.Domain.Specifications.Goals;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed class GetUserGoalsQueryHandler : IRequestHandler<GetUserGoalsQuery, UserGoalsDto>
{
    private readonly ICurrentApplicationUser _currentApplicationUser;
    private readonly IRepository<Goal> _goalRepository;
    private readonly IMapper _mapper;

    public GetUserGoalsQueryHandler(IRepository<Goal> goalRepository, ICurrentApplicationUser currentApplicationUser, IMapper mapper)
    {
        _goalRepository = goalRepository;
        _currentApplicationUser = currentApplicationUser;
        _mapper = mapper;
    }

    public async Task<UserGoalsDto> Handle(GetUserGoalsQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var goals = await _goalRepository.ListAsync(
            new GoalsByUserIdPagedAsNoTrackingSpec(userId, request.SearchText, request.PaginationParameters.PerPage, request.PaginationParameters.Page), 
            cancellationToken);
        var goalsCount = await _goalRepository.CountAsync(new GoalsByUserIdSpec(userId), cancellationToken);

        var goalsDtos = _mapper.Map<IReadOnlyCollection<GoalShortInfoDto>>(goals);

        return new UserGoalsDto(goalsDtos, goalsCount);
    }
}
