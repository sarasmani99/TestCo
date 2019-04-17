using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TestCo.Weather.Services.WeatherMap.WeatherMapApi;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public class ForecastApiClient : IForecastApiClient
    {
        private readonly IFlurlClient _client;
        private readonly WeatherMapApiSettings _settings;
        public ForecastApiClient(IFlurlClient client, WeatherMapApiSettings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<ForecastResult> GetForecastForCity(string city)
        {
            return await _client.Request("forecast")
                .SetQueryParam("q", city)
                .SetQueryParam("units", "metric")
                .SetQueryParam("appid", _settings.AppId)
                .GetJsonAsync<ForecastResult>();
        }
    }
}
