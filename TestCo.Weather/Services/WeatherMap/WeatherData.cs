using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCo.Weather.Services.WeatherMap.WeatherMapApi;

namespace TestCo.Weather.Services.WeatherMap
{
    public class WeatherData
    {
        public float Temperature { get; set; }
        public DateTime Date { get; set; }
        public WeatherCondition Condition { get; set; }

        public static WeatherData From(ForecastItem forecast)
        {
            var result = new WeatherData
            {
                Date = forecast.Date.Date, Temperature = forecast.TemperatureInfo.MaxTemperature
            };

            switch (forecast.WeatherInfos.FirstOrDefault()?.Id ?? 0)
            {
                case int n when (n >= 200 && n<=232):
                    result.Condition = WeatherCondition.Thunderstorm;
                    break;
                case int n when (n >= 500 && n <= 531):
                    result.Condition = WeatherCondition.Drizzle;
                    break;
                case int n when (n >= 600 && n <= 622):
                    result.Condition = WeatherCondition.Snow;
                    break;
                case int n when (n == 800):
                    result.Condition = WeatherCondition.Clear;
                    break;
                case int n when (n >= 801 && n <= 804):
                    result.Condition = WeatherCondition.Clouds;
                    break;
            }
            return result;
        }
    }

    public enum WeatherCondition
    {
        Unknown,
        Thunderstorm,
        Drizzle,
        Rain,
        Snow,
        Clear,
        Clouds
    }
}
