using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IWeatherDAO
    {
        void AddWeather(WeatherDTO dto);
        WeatherDTO GetWeatherById(int weatherId);
        WeatherListDTO GetWeatherList();
        WeatherListDTO GetWeatherListByUserId(int userId);
        void UpdateWeather(WeatherDTO dto);
        void DeleteWeather(int weatherId);
        void DeleteWeatherByUserId(int userId);

    }
}
