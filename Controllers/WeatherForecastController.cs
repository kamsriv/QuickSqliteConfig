using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quickapp_del.DataModel;
using Quickapp_del.Modal;

namespace Quickapp_del.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DBConnect _con;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBConnect conn)
        {
            _logger = logger;
            _con = conn;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetPeople/{sr?}", Name = "People")]
        public IEnumerable<dynamic> GetPeople(string sr="pe")
        {
            return from p in _con.People 
                     join a in _con.Addresses on p.Address.Id equals a.Id
                     select new {p,a};
        }
    }
}