namespace EasyGoal.Backend.Application.Abstractions.Presentation;
public interface ICurrentApplicationUser
{
    Guid? Id { get; }
    string? UserName { get; }
    string? Email { get; }
    string? FullName { get; }
}
