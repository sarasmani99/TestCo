using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public class WeatherInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Classification { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
