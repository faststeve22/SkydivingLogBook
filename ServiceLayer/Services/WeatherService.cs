using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDAO _weatherDAO;
        private readonly IUserService _userService;

        public WeatherService(IWeatherDAO weatherDAO, IUserService userService)
        {
            _weatherDAO = weatherDAO;
            _userService = userService;
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

        public WeatherListDTO GetWeatherListByUserId()
        {
            return new WeatherListDTO(_weatherDAO.GetWeatherListByUserId(_userService.GetUserId()));
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

        public void DeleteWeatherByUserId()
        {
            _weatherDAO.DeleteWeatherByUserId(_userService.GetUserId());
        }
    }
}
