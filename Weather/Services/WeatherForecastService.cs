using System.Collections.Generic;
using Weather.Dtos;
using Weather.Services;

namespace Weather.Controllers
{
    public class WeatherForecastService
    {
        /// <summary>
        /// Get forecast from wunderground.com and openweathermap.org
        /// </summary>
        /// <param name="model">index model</param>
        /// <returns></returns>
        public IEnumerable<WeatherForecast> GetWeather(List<Location> locations)
        {
            var result = new List<WeatherForecast>();
            foreach (var location in locations)
            {
                var forecast = new WeatherForecast();
                forecast.Location = location;
                IForecast forecastService = new ForecastWU();
                forecast.Forecasts.Add(forecastService.GetForecast(location.City, location.Country));
                forecastService = new ForecastOWM();
                forecast.Forecasts.Add(forecastService.GetForecast(location.City, location.Country));
                result.Add(forecast);
            }
            
            return result;
        }
    }
}