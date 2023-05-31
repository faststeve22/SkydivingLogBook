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
        public IActionResult Get()
        {
            return Ok(_weatherService.GetWeatherList());
        }

        [Authorize]
        [HttpGet("{WeatherId}")]
        public IActionResult Get(int id)
        {
            return Ok(_weatherService.GetWeatherById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] WeatherDTO dto)
        {
            _weatherService.AddWeather(dto);
            return Ok();
        }

        [Authorize]
        [HttpPut("{WeatherId}")]
        public IActionResult Put([FromBody] WeatherDTO dto)
        {
            _weatherService.UpdateWeather(dto);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{WeatherId}")]
        public IActionResult Delete(int id)
        {
            _weatherService.DeleteWeather(id);
            return Ok();
        }
    }
}
