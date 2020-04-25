using Newtonsoft.Json;
using System.IO;
using System.Net;
using Weather.Controllers.JsonModels;
using Weather.Dtos;

namespace Weather.Services
{
    public class ForecastOWM : IForecast
    {
        private string _urlPart = "http://api.openweathermap.org/data/2.5/weather?q=";
        /// <summary>
        /// Get forecast from openweathermap.org 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public ForecastModel GetForecast(string city, string country)
        {
            var forecastOWM = GetWeatherOWM(city);
            var forecast = new ForecastModel
            {
                Temperature = forecastOWM.Main.Temp.ToString(),
                Pressure = forecastOWM.Main.pressure.ToString(),
                Humibity = forecastOWM.Main.humbity.ToString(),
                Wind = $"Скорость: {forecastOWM.Wind.speed}, Направление: {forecastOWM.Wind.deg}",
                Cloudiness = ""
            };
            return forecast;
        }

        private WeatherResponceOWM GetWeatherOWM(string city)
        {

            var url = _urlPart + city + "&units=metric&appid=1ae53a9fe9ca665c0eec2d741c52bf83";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponceOWM WR = new WeatherResponceOWM();

                WR = JsonConvert.DeserializeObject<WeatherResponceOWM>(response);
                return WR;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        WeatherResponceOWM WR = new WeatherResponceOWM();
                        WR.name = "Not found";
                        return WR;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
