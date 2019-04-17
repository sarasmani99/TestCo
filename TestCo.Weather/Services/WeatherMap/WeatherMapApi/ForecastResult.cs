using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public class ForecastResult
    {
        [JsonProperty("cod")]
        public int Code { get; set; }

        [JsonProperty("list")]
        public ForecastItem[] Items { get; set; }
    }

}
