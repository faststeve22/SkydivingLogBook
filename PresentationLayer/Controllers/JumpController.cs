using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Logbook.PresentationLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JumpController : ControllerBase
    {
        private readonly IJumpService _jumpService;

        public JumpController(IJumpService jumpService)
        {
            _jumpService = jumpService;
        }

        [Authorize]
        [HttpGet("{jumpId}")]
        public JumpDTO Get(int jumpId)
        {
            return _jumpService.GetJumpById(jumpId);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] JumpDTO jumpDTO)
        {
            _jumpService.AddJump(jumpDTO);
        }

        [Authorize]
        [HttpPut]
        public void Put([FromBody] JumpDTO jumpDTO)
        {
            _jumpService.UpdateJump(jumpDTO);
        }

        [Authorize]
        [HttpDelete("{JumpId}")]
        public void Delete(int jumpId)
        {
            _jumpService.DeleteJump(jumpId);
        }
    }
}
