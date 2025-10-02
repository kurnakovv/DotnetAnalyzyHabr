using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DotnetAnalyzyHabr.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        List<User> users = [];

        //User item = users.FirstOrDefault(x => x.Name == "Vasia");
        //var a = item.Name;

        //            switch (expression)
        //            {
        //#pragma warning disable CS8602
        //                case x:
        //                    // ~5к строчек кода...
        //                    break;
        //#pragma warning restore CS8602
        //                case y:
        //                    // ~5к строчек кода...
        //                    break;
        //#pragma warning disable CS8602
        //                default:
        //                    // ~5к строчек кода...
        //                    break;
        //#pragma warning disable CS8602
        //            }

        //            var days = 2;
        //            switch (days)
        //            {
        //#pragma warning disable CS8602
        //                case 1:
        //                    // ~5к строчек кода
        //                    User? item1 = users.FirstOrDefault(x => x.Name == "Vasia");
        //                    var a1 = item1.Name;
        //                    break;
        //#pragma warning restore CS8602
        //                case 2:
        //                    // ~5к строчек кода
        //                    User item2 = users.FirstOrDefault(x => x.Name == "Vasia");
        //                    var a2 = item2.Name;
        //                    break;
        //#pragma warning disable CS8602
        //                default:
        //                    // ~5к строчек кода
        //                    break;
        //#pragma warning disable CS8602
        //            }

        return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
        })];
    }

    [HttpGet(Name = "GetTest")]
    public async Task<IEnumerable<WeatherForecast>> GetTestAsync()
    {
        List<User> users = [];

        await Task.Run(() => { });

        return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
        })];
    }
}

public class User
{
    public required string Name { get; set; }
}
