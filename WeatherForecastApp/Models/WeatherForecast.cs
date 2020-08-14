using System;

namespace WeatherForecastApp.Models
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public string DateFormatted
        {
            get
            {
                return Date.ToString("dd/MM/yyyy");
            }
        }
        public int TemperatureC { get; set; }
        public double TemperatureCMax { get; set; }
        public double TemperatureCMin { get; set; }
        public WeatherState WeatherState { get; set; }
    }

    public struct WeatherState
    {
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbreviation { get; set; }
    }
}
