using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestCo.Weather.Services.WeatherMap
{
    public interface IForecastService
    {
        Task<List<WeatherData>> QueryForecast(string city);
        Task<List<WeatherData>> QueryForecast(string city, int minTemperature);

        Task<List<WeatherData>> QueryForecast(string city, WeatherCondition condition);
    }
}
