using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public class ForecastItem
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("main")]
        public TemperatureInfo TemperatureInfo { get; set; }

        [JsonProperty("weather")]
        public WeatherInfo[] WeatherInfos { get; set; }
    }
}
