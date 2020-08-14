using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class MetaWeatherForecast
    {
        [JsonProperty("consolidated_weather")]
        public ConsolidatedWeather[] ConsolidatedWeather { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("sun_rise")]
        public DateTimeOffset SunRise { get; set; }

        [JsonProperty("sun_set")]
        public DateTimeOffset SunSet { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public long Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
