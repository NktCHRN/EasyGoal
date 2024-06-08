namespace EasyGoal.Backend.Application.Features.Account.Dto;
public sealed record LoginResultDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
