using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Calendars.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Calendars.Queries;
public sealed class GetWeeklyCalendarQueryHandler : IRequestHandler<GetWeeklyCalendarQuery, CalendarEventsDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public GetWeeklyCalendarQueryHandler(IRepository<Task> taskRepository, IMapper mapper, ICurrentApplicationUser currentApplicationUser)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task<CalendarEventsDto> Handle(GetWeeklyCalendarQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var tasks = await _taskRepository.ListAsync(new TasksByDatesAsNoTrackingSpec(request.Start, request.End, userId), cancellationToken);

        return new CalendarEventsDto(_mapper.Map<IReadOnlyList<CalendarTaskDto>>(tasks));
    }
}
