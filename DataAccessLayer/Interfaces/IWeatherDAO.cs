using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IWeatherDAO
    {
        public void AddWeather(Weather weather);
        public Weather GetWeatherById(int weatherId);
        public WeatherList GetWeatherList();
        public WeatherList GetWeatherListByUserId(int userId);
        public void UpdateWeather(Weather weather);
        public void DeleteWeather(int weatherId);
        public void DeleteWeatherByUserId(int userId);

    }
}
