using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IWeatherService
    {
        public void AddWeather(WeatherDTO dto);
        public Weather GetWeatherById(int weatherId);
        public WeatherList GetWeatherList();
        public WeatherList GetWeatherListByUserId(int userId);
        public void UpdateWeather(WeatherDTO dto);
        public void DeleteWeather(int weatherId);
    }
}
