using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("[action]")]
        [Route("forecast/{location}")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Forecast(string location)
        {
            IEnumerable<WeatherForecast> forecasts;
            try
            {
                forecasts = await _weatherService.GetWeatherForecast(location.ToLower());
            }
            catch (ArgumentException)
            {
                return BadRequest($"{location} is invalid");
            }

            return Ok(forecasts);
        }
    }
}
