using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCo.Weather.Services.WeatherMap.WeatherMapApi;
using System.Linq;

namespace TestCo.Weather.Services.WeatherMap
{
    public class ForecastService: IForecastService
    {
        private readonly IForecastApiClient _client;

        public ForecastService(IForecastApiClient client)
        {
            _client = client;
        }
        public async Task<List<WeatherData>> QueryForecast(string city)
        {
            var apiResult = await _client.GetForecastForCity(city);
            return apiResult.Items.Select(WeatherData.From).ToList();
        }

        public async Task<List<WeatherData>> QueryForecast(string city,int minTemperature)
        {
            var result = await QueryForecast(city);
            var filtered =from item in result
                group item by item.Date
                into itemsByDate
                select new WeatherData()
                {
                    Date = itemsByDate.Key,
                    Temperature = itemsByDate.Max(x => x.Temperature),
                    Condition =  WeatherCondition.Unknown
                };

            return filtered.Where(x=>x.Temperature>minTemperature).ToList();
        }

        public async Task<List<WeatherData>> QueryForecast(string city, WeatherCondition condition)
        {
            var result = await QueryForecast(city);
            var filtered = from item in result
                where item.Condition==condition
                group item by item.Date
                into itemsByDate
                select new WeatherData()
                {
                    Date = itemsByDate.Key,
                    Temperature = itemsByDate.Max(x => x.Temperature),
                    Condition = itemsByDate.FirstOrDefault()?.Condition ?? WeatherCondition.Unknown
                };

            return filtered.ToList();
        }
    }
}
