using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_aircraftService.GetAircraftList());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetAircraftById(int id)
        {
            return Ok(_aircraftService.GetAircraftById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AircraftDTO aircraftDTO)
        {
                AircraftDTO CreatedAircraft = _aircraftService.AddAircraft(aircraftDTO);
                return CreatedAtAction(nameof(Get), new { id = CreatedAircraft.AircraftId }, CreatedAircraft);
        }

        [Authorize]
        [HttpPut("{aircraftId}")]
        public IActionResult Put([FromBody] AircraftDTO aircraftDTO)
        {
                _aircraftService.UpdateAircraft(aircraftDTO);
                return NoContent();
        }

        [Authorize]
        [HttpDelete("{aircraftId}")]
        public IActionResult Delete(int aircraftId)
        {
                _aircraftService.DeleteAircraft(aircraftId);
                return NoContent();
        }
    }
}
