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
        public IActionResult Get(int jumpId)
        {
            return Ok(_jumpService.GetJumpById(jumpId));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] JumpDTO jumpDTO)
        {
            JumpDTO CreatedJump = _jumpService.AddJump(jumpDTO);
            return CreatedAtAction(nameof(Get), new {id = CreatedJump.JumpId}, CreatedJump);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] JumpDTO jumpDTO)
        {
            _jumpService.UpdateJump(jumpDTO);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{jumpId}")]
        public IActionResult Delete(int jumpId)
        {
            _jumpService.DeleteJump(jumpId);
            return NoContent();
        }
    }
}
