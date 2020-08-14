using Newtonsoft.Json;
using System;

namespace WeatherForecastApp.Models
{
    public class ConsolidatedWeather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("applicable_date")]
        public DateTimeOffset ApplicableDate { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("the_temp")]
        public double TheTemp { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_direction")]
        public double WindDirection { get; set; }

        [JsonProperty("air_pressure")]
        public double AirPressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("predictability")]
        public long Predictability { get; set; }
    }
}