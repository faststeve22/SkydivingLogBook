using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

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
            _weatherDAO.AddWeather(ConvertDTOToModel(dto)); 
        }

        public Weather GetWeatherById(int weatherId)
        {
            return _weatherDAO.GetWeatherById(weatherId);   
        }

        public WeatherList GetWeatherList()
        {
            return _weatherDAO.GetWeatherList();
        }

        public WeatherList GetWeatherListByUserId(int userId)
        {
            return _weatherDAO.GetWeatherListByUserId(userId);
        }

        public void UpdateWeather(WeatherDTO dto)
        {
            _weatherDAO.UpdateWeather(ConvertDTOToModel(dto));
        }

        public void DeleteWeather(int weatherId)
        {
            _weatherDAO.DeleteWeather(weatherId);
        }
        private Weather ConvertDTOToModel(WeatherDTO dto)
        {
            Weather weather = new Weather(); 
            if(weather.WeatherId != 0)
            {
                weather.WeatherId = dto.WeatherId;
            }
            weather.GroundTemperature = dto.GroundTemperature;
            weather.GroundWindSpeed = dto.GroundWindSpeed;
            weather.GroundWindDirectionAtTakeoff = dto.GroundWindDirectionAtTakeoff;
            weather.GroundWindDirectionAtLanding = dto.GroundWindDirectionAtLanding;
            weather.TemperatureAtJumpAltitude = dto.TemperatureAtJumpAltitude;
            weather.Notes = dto.Notes;
            return weather;
        }
    }
}
