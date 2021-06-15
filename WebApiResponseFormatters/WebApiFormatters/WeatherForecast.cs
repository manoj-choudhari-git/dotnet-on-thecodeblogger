using System;

using Newtonsoft.Json;

namespace WebApiFormatters
{
    public class WeatherForecast
    {
        [JsonProperty("d")]
        public DateTime Date { get; set; }

        [JsonProperty("tempC")]
        public int TemperatureC { get; set; }

        [JsonProperty("tempF")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
