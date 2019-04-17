using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestCo.Weather.Services.WeatherMap.WeatherMapApi
{
    public interface IForecastApiClient
    {
        Task<ForecastResult> GetForecastForCity(string city);
    }
}
