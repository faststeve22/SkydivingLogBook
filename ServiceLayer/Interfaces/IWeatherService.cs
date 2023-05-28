using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IWeatherService
    {
        public void AddWeather(WeatherDTO dto);
        public WeatherDTO GetWeatherById(int weatherId);
        public WeatherListDTO GetWeatherList();
        public WeatherListDTO GetWeatherListByUserId();
        public void UpdateWeather(WeatherDTO dto);
        public void DeleteWeather(int weatherId);
        public void DeleteWeatherByUserId(int weatherId);
    }
}
