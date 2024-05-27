namespace EasyGoal.Backend.Domain.Entities;
public class Goal
{
    public Guid UserId { get; set; }
    public IReadOnlyList<SwotPoint> SwotPoints => _swotPoints.AsReadOnly();
    private readonly List<SwotPoint> _swotPoints = [];
}
