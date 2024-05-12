using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyGoal.Backend.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly LinkGenerator _linkGenerator;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, LinkGenerator linkGenerator)
    {
        _logger = logger;
        _linkGenerator = linkGenerator;
    }

    [HttpGet("current", Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(ApiResponse<WeatherForecast>.FromResult(new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(0)), Random.Shared.Next(-20, 55), Summaries[Random.Shared.Next(Summaries.Length)])
        {
            Links = [new("Name1", "GET", _linkGenerator.GetUriByName(HttpContext, "GetWeatherForecast")!)]
        }));
    }
}
