using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace WebApiSample.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Hello"
            })
            .ToArray();
            
        }


        [HttpGet(Name = "GetForecast")]
        public IActionResult GetForecast(string country)
        {

            CountryWeather cw = new CountryWeather();
            OneOf<Country, InvalidCountryCode, NotSupportedCountry> oneOfCw = cw.GetCountryWeather(country);

            return oneOfCw.Match<IActionResult>(Country => Ok(Country),
                InvalidCountryCode => BadRequest(InvalidCountryCode),
                NotSupportedCountry => UnprocessableEntity(NotSupportedCountry)
                );



        }

    }

    public interface IWeatherService 
    {
       OneOf<Country, InvalidCountryCode, NotSupportedCountry> GetCountryWeather(string country);
    }

    public class CountryWeather :IWeatherService
    {
        public OneOf<Country, InvalidCountryCode, NotSupportedCountry> GetCountryWeather(string country) 
        {
            if (string.IsNullOrEmpty(country)) 
            {
                return new InvalidCountryCode();
            
            }

            if (country.ToUpper()== "RUSSIA") 
            {
                return new NotSupportedCountry();
            }

            return new Country();
            
        }
       
    
    }

    public struct Country
    {
        public string CountryWeather { get; set; }

        public Country() 
        {
            CountryWeather = "Very Cold";
        }

    }
    public struct InvalidCountryCode
    {
        public string InvalidCountryCodeMessage { get; set; }

        public InvalidCountryCode()
        {
            InvalidCountryCodeMessage = "Invalid Code";
        }
    }

    public struct NotSupportedCountry
    {
        public string NotSupportedCountryMessage { get; set; }

        public NotSupportedCountry()
        {
            NotSupportedCountryMessage = "Country No Supported";
        }

    }
}