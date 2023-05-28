using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropzoneController : ControllerBase
    {
        private readonly IDropzoneService _dropzoneService;

        public DropzoneController(IDropzoneService dropzoneService)
        {
            _dropzoneService = dropzoneService;
        }

        [Authorize]
        [HttpGet]
        public DropzoneListDTO Get()
        {
            return _dropzoneService.GetDropzoneList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public DropzoneDTO Get(int id)
        {
            return _dropzoneService.GetDropzoneById(id);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] DropzoneDTO dto)
        {
            _dropzoneService.AddDropzone(dto);
        }

        [Authorize]
        [HttpPut("{DropzoneId}")]
        public void Put([FromBody] DropzoneDTO dto)
        {
            _dropzoneService.UpdateDropzone(dto);
        }

        [Authorize]
        [HttpDelete("{DropzoneId}")]
        public void Delete(int id)
        {
            _dropzoneService.DeleteDropzone(id);
        }
    }
}
