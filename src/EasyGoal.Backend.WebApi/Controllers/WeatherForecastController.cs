using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : BaseController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("current", Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        var response = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(0)), Random.Shared.Next(-20, 55), Summaries[Random.Shared.Next(Summaries.Length)]);
        return OkResponse(response);
    }
}
