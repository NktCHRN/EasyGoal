using AutoMapper;
using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.Application.Features.Calendars.Dto;
using EasyGoal.Backend.Application.Features.Tasks.Dto;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Domain.Specifications.Tasks;
using MediatR;
using Task = EasyGoal.Backend.Domain.Entities.Task.Task;

namespace EasyGoal.Backend.Application.Features.Calendars.Queries;
public sealed class GetDailyCalendarQueryHandler : IRequestHandler<GetDailyCalendarQuery, DailyCalendarEventsDto>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentApplicationUser _currentApplicationUser;

    public GetDailyCalendarQueryHandler(IRepository<Task> taskRepository, IMapper mapper, ICurrentApplicationUser currentApplicationUser)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _currentApplicationUser = currentApplicationUser;
    }

    public async Task<DailyCalendarEventsDto> Handle(GetDailyCalendarQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentApplicationUser.GetValidatedId();
        var start = new DateTimeOffset(
            request.UserCurrentDateTime.Year, 
            request.UserCurrentDateTime.Month, 
            request.UserCurrentDateTime.Day, 
            0,
            0,
            0,
            request.UserCurrentDateTime.Offset);
        var end = start.AddDays(1);
        var tasks = await _taskRepository.ListAsync(new TasksWithSubTasksByDatesAsNoTrackingSpec(start, end, userId), cancellationToken);

        return new DailyCalendarEventsDto(_mapper.Map<IReadOnlyList<TaskShortInfoDto>>(tasks));
    }
}
