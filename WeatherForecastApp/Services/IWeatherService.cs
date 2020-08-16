using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Retrieves weather forecast for specified location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>IEnumerable<WeatherForecast> or null if weather forecast could not be retrieved</returns>
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast(string location);
    }
}
