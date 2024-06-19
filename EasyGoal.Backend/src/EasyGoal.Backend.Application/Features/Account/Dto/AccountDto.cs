namespace EasyGoal.Backend.Application.Features.Account.Dto;
public record AccountDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }
}
