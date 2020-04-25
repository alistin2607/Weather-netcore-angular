using Weather.Dtos;

namespace Weather.Services
{
    interface IForecast
    {
        /// <summary>
        /// Get forecast by city and country
        /// </summary>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        ForecastModel GetForecast(string city, string country);
    }
}
