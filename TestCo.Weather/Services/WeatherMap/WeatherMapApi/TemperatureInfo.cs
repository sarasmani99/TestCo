using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public class TemperatureInfo
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemperature { get; set; }

        [JsonProperty("temp_min")]
        public float MinTemperature { get; set; }
    }
}
