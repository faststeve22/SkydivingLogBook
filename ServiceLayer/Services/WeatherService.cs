using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Logbook.ServiceLayer.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDAO _weatherDAO;

        public WeatherService(IWeatherDAO weatherDAO)
        {
            _weatherDAO = weatherDAO;
        }

        public void AddWeather(WeatherDTO dto)
        {
            Weather weather = new Weather(dto);
            _weatherDAO.AddWeather(weather); 
        }

        public WeatherDTO GetWeatherById(int weatherId)
        {
            return new WeatherDTO(_weatherDAO.GetWeatherById(weatherId));   
        }

        public WeatherListDTO GetWeatherList()
        {
            return new WeatherListDTO(_weatherDAO.GetWeatherList());
        }

        public WeatherListDTO GetWeatherListByUserId(int userId)
        {
            return new WeatherListDTO(_weatherDAO.GetWeatherListByUserId(userId));
        }

        public void UpdateWeather(WeatherDTO dto)
        {
            Weather weather = new Weather(dto);
            _weatherDAO.UpdateWeather(weather);
        }

        public void DeleteWeather(int weatherId)
        {
            _weatherDAO.DeleteWeather(weatherId);
        }

        public void DeleteWeatherByUserId(int userId)
        {
            _weatherDAO.DeleteWeatherByUserId(userId);
        }
    }
}
