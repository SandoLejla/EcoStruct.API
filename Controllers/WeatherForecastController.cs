using Microsoft.AspNetCore.Mvc;

namespace EcoStruct.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IWeatherForecastService _weatherForecastService;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, 
			IWeatherForecastService weatherForecastService)
		{
			_logger = logger;
			_weatherForecastService = weatherForecastService;
		}

		[HttpGet]
		[Route("{take}/example")]
		public IEnumerable<WeatherForecast> Get([FromQuery]int max, [FromRoute]int take)
		{
			var result = _weatherForecastService.Get();
			return result; 
		}

		[HttpGet("currentDay")]
		//[HttpGet(Name = "GetWeatherForecast")]
		public WeatherForecast GetCurrentDayForecast()
		{
			var result = _weatherForecastService.Get().First();
			return result;
		}

		[HttpPost]
		public string Hello([FromBody] string name)
		{
			return $"Hello {name}";
		}
	}
}
