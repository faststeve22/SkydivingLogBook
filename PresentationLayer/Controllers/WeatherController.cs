using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Authorize]
        [HttpGet]
        public WeatherListDTO Get()
        {
            return _weatherService.GetWeatherList();
        }

        [Authorize]
        [HttpGet("{WeatherId}")]
        public WeatherDTO Get(int id)
        {
            return _weatherService.GetWeatherById(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] WeatherDTO dto)
        {
            _weatherService.AddWeather(dto);
        }

        [Authorize]
        [HttpPut("{WeatherId}")]
        public void Put([FromBody] WeatherDTO dto)
        {
            _weatherService.UpdateWeather(dto);
        }

        [Authorize]
        [HttpDelete("{WeatherId}")]
        public void Delete(int id)
        {
            _weatherService.DeleteWeather(id);
        }
    }
}
