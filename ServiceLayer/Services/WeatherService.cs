using Logbook.DataAccessLayer.Interfaces;
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
            _weatherDAO.AddWeather(dto); 
        }

        public WeatherDTO GetWeatherById(int weatherId)
        {
            return _weatherDAO.GetWeatherById(weatherId);   
        }

        public WeatherListDTO GetWeatherList()
        {
            return _weatherDAO.GetWeatherList();
        }

        public WeatherListDTO GetWeatherListByUserId()
        {
            return _weatherDAO.GetWeatherListByUserId(_userService.GetUserId());
        }

        public void UpdateWeather(WeatherDTO dto)
        {
            _weatherDAO.UpdateWeather(dto);
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
