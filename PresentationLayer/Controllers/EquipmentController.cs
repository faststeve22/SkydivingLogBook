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
        public EquipmentListDTO Get()
        {
            return _equipmentService.GetEquipmentList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public EquipmentDTO Get(int equipmentId)
        {
            return _equipmentService.GetEquipmentById(equipmentId);
        }

        [Authorize]
        [HttpGet]

        public EquipmentListDTO GetEquipmentByUser()
        {
            return _equipmentService.GetEquipmentListByUserId();
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] EquipmentDTO dto)
        {
            _equipmentService.AddEquipment(dto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put([FromBody] EquipmentDTO dto)
        {
            _equipmentService.UpdateEquipment(dto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _equipmentService.DeleteEquipment(id);
        }
    }
}
