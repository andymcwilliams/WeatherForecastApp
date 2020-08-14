using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class MetaWeatherService : IWeatherService
    {
        IRestClient _client;

        public MetaWeatherService(IRestClient restClient)
        {
            _client = restClient;
        }

        private async Task<int> GetWorldId(string location)
        {
            var request = new RestRequest($"location/search/?query={location}", Method.GET);

            var result = await _client.ExecuteAsync(request);

            var locationSearchList = new List<LocationSearch>();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                locationSearchList = JsonConvert.DeserializeObject<List<LocationSearch>>(result.Content);
            }

            if (locationSearchList.Count > 0)
            {
                // returns a list, we only care about the first result
                var locationSearch = locationSearchList[0];

                return locationSearch.WorldId;
            }
            else
            {
                throw new ArgumentException($"{location} not found", "location");
            }
        }

        private async Task<MetaWeatherForecast> GetForecasts(int worldId)
        {
            var request = new RestRequest($"location/{worldId}", Method.GET);

            var result = await _client.ExecuteAsync(request);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var forecasts = JsonConvert.DeserializeObject<MetaWeatherForecast>(result.Content);

                return forecasts;
            }
            else
            {
                throw new ArgumentException($"Failed to get forecast for world id: {worldId}", "worldId");
            }
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(string location)
        {
            var worldId = await GetWorldId(location);

            var metaForecasts = await GetForecasts(worldId);

            // transform metaWeatherForecast into generic weather forecast
            List<WeatherForecast> forecasts = new List<WeatherForecast>();

            foreach (var forecast in metaForecasts.ConsolidatedWeather)
            {
                forecasts.Add(new WeatherForecast
                {
                    Date = forecast.ApplicableDate,
                    TemperatureCMax = forecast.MaxTemp,
                    TemperatureCMin = forecast.MinTemp,
                    WeatherState = new WeatherState
                    {
                        WeatherStateAbbreviation = forecast.WeatherStateAbbr,
                        WeatherStateName = forecast.WeatherStateName
                    }
                });
            }

            return forecasts;
        }
    }
}
