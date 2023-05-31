using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_equipmentService.GetEquipmentList());
        }

        [Authorize]
        [HttpGet("{equipmentId}")]
        public IActionResult Get(int equipmentId)
        {
            return Ok(_equipmentService.GetEquipmentById(equipmentId));
        }

        [Authorize]
        [HttpGet("User")]

        public IActionResult GetEquipmentByUser()
        {
            return Ok(_equipmentService.GetEquipmentListByUserId());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] EquipmentDTO dto)
        {
            EquipmentDTO CreatedEquipment = _equipmentService.AddEquipment(dto);
            return CreatedAtAction(nameof(Get), new { id = CreatedEquipment.EquipmentId }, CreatedEquipment);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] EquipmentDTO dto)
        {
            _equipmentService.UpdateEquipment(dto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _equipmentService.DeleteEquipment(id);
            return NoContent();
        }
    }
}
