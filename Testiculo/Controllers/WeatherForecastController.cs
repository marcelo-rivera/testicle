using Microsoft.AspNetCore.Mvc;
using Testiculo.Persistence;
using Testiculo.Domain;
using Testiculo.Persistence.Contexto;
namespace Testiculo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    private readonly TesticuloContext _context;
        
    public WeatherForecastController(TesticuloContext context)
    {
        _context = context;
            
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        //return _evento; 
        return _context.WeatherForecasts;
    }
        
    [HttpGet("{id}")]
    public IEnumerable<WeatherForecast> GetById(int id)
    {
        //return _evento.Where(evento => evento.EventoId == id);
        return _context.WeatherForecasts.Where(evento => evento.Id == id);
    }
}
