using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
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

        [HttpGet]
        public AircraftListDTO Get()
        {
            return _aircraftService.GetAircraftList();
        }

        [HttpGet("{id}")]
        public AircraftDTO GetAircraftById(int id)
        {
            return _aircraftService.GetAircraftById(id);
        }

        [HttpPost]
        public void Post([FromBody] AircraftDTO aircraftDTO)
        {
            _aircraftService.AddAircraft(aircraftDTO);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] AircraftDTO aircraftDTO)
        {
            _aircraftService.UpdateAircraft(aircraftDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(int aircraftId)
        {
            _aircraftService.DeleteAircraft(aircraftId);
        }
    }
}
