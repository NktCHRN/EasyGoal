using EasyGoal.Backend.Application.Features.Goals.Dto;
using MediatR;

namespace EasyGoal.Backend.Application.Features.Goals.Queries;
public sealed class GetUserGoalsQueryHandler : IRequestHandler<GetUserGoalsQuery, UserGoalsDto>
{
    public Task<UserGoalsDto> Handle(GetUserGoalsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
