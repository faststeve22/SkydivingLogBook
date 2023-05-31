using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IWeatherService
    {
         WeatherDTO AddWeather(WeatherDTO dto);
         WeatherDTO GetWeatherById(int weatherId);
         WeatherListDTO GetWeatherList();
         WeatherListDTO GetWeatherListByUserId();
         void UpdateWeather(WeatherDTO dto);
         void DeleteWeather(int weatherId);
         void DeleteWeatherByUserId();
    }
}
