using Weather.Dtos;

namespace Weather.Services
{
    public class ForecastWU : IForecast
    {
        private string _urlPart = "http://api.wunderground.com/api/c4bb30b97572d3ed/conditions/q/CA";
        /// <summary>
        /// Get forecast from wunderground.com
        /// </summary>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public ForecastModel GetForecast(string city, string country)
        {

            var forecast = new ForecastModel();
            return null;
        }

        //TODO Add private method for get forecast from wunderground.com
    }
}
