using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Services;
using Xunit;

namespace WeatherForecastAppTests
{
    public class MetaWeatherServiceTests
    {
        private readonly MetaWeatherService _weatherService; 

        public MetaWeatherServiceTests()
        {
            var restClient = new RestClient("https://www.metaweather.com/api/");

            _weatherService = new MetaWeatherService(restClient);
        }

        [Fact]
        public async Task MetaWeatherService_RetrieveForecastForValidLocation_ForecastRetrieved()
        {
            var forecasts = await _weatherService.GetWeatherForecast("belfast");

            Assert.True(forecasts.ToList().Count > 0);
        }

        [Fact]
        public async Task MetaWeatherService_RetrieveForecastForInvalidLocation_NullReturned()
        {
            var forecasts = await _weatherService.GetWeatherForecast("narnia");

            Assert.Null(forecasts);
        }
    }
}
