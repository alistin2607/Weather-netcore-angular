using System.Collections.Generic;

namespace Weather.Dtos
{
    public class WeatherForecast
    {
        public Location Location { get; set; }
        public List<ForecastModel> Forecasts { get; set; }
    }

   
}
