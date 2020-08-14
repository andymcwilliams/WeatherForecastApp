using Newtonsoft.Json;

namespace WeatherForecastApp.Models
{
    public class LocationSearch
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public int WorldId { get; set; }

        [JsonProperty("latt_long")]
        public string LatitudeLongitude { private get; set; }

        public string Latitude
        {
            get
            {
                return LatitudeLongitude.Split(',')[0];
            }
        }

        public string Longitude
        {
            get
            {
                return LatitudeLongitude.Split(',')[1];
            }
        }
    }
}
