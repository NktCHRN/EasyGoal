using EasyGoal.Backend.WebApi.Contracts.Responses.Common;

namespace EasyGoal.Backend.WebApi;

public record WeatherForecast(DateOnly Date,

int TemperatureC,

string? Summary) : BaseModelResponse
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
