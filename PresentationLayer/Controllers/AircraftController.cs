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
        public AircraftListDTO Get()
        {
            return _aircraftService.GetAircraftList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public AircraftDTO GetAircraftById(int id)
        {
            return _aircraftService.GetAircraftById(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] AircraftDTO aircraftDTO)
        {
            _aircraftService.AddAircraft(aircraftDTO);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put([FromBody] AircraftDTO aircraftDTO)
        {
            _aircraftService.UpdateAircraft(aircraftDTO);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int aircraftId)
        {
            _aircraftService.DeleteAircraft(aircraftId);
        }
    }
}
