using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IWeatherDAO
    {
        public void AddWeather(Weather weather);
        public Weather GetWeather(int weatherId);
        public WeatherList GetWeatherList(int userId);
        public void UpdateWeather(Weather weather);
        public void DeleteWeather(int weatherId);
    }
}
