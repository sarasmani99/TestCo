using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Flurl.Http;
using TestCo.Weather.Services.WeatherMap;
using TestCo.Weather.Services.WeatherMap.WeatherMapApi;
using console=System.Console;
namespace TestCo.Weather.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            var settings = new WeatherMapApiSettings()
            {
                Url = ConfigurationManager.AppSettings["WeatherMapApi.Url"],
                AppId = ConfigurationManager.AppSettings["WeatherMapApi.Appid"]
            };

            builder.Register(x => new FlurlClient(settings.Url))
                .As<IFlurlClient>()
                .SingleInstance();

            builder.RegisterInstance(settings);
            builder.RegisterType<ForecastApiClient>().As<IForecastApiClient>();
            builder.RegisterType<ForecastService>().As<IForecastService>();

            var container = builder.Build();

            Run(container).GetAwaiter().GetResult();
        }

        static async Task Run(IContainer container)
        {
            var service = container.Resolve<IForecastService>();

            var daysWhenTemperatureIs20OrAbove = await service.QueryForecast("Sydney", 20);
            var sunnyDays = await service.QueryForecast("Sydney", WeatherCondition.Clear);

            console.WriteLine("Days when Temperature is 20 and above");
            DisplayResult(daysWhenTemperatureIs20OrAbove);

            console.WriteLine("Sunny days");
            DisplayResult(sunnyDays);

            console.ReadLine();
        }

        static void DisplayResult(IEnumerable<WeatherData> data)
        {
            console.WriteLine("---------------------------------------");
            foreach (var weatherData in data)
            {
                console.WriteLine($"{weatherData.Date:dd MMMM yyyy} {(weatherData.Condition==WeatherCondition.Unknown?string.Empty:weatherData.Condition.ToString())} {weatherData.Temperature}");
            }
            console.WriteLine("---------------------------------------");
        }
    }
}
