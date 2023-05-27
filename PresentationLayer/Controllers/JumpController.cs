using Logbook.Models;
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
        private readonly IJumpLogService _jumpLogService;
        private readonly IJumpService _jumpService;

        public JumpController(IJumpLogService jumpLogService, IJumpService jumpService)
        {
            _jumpLogService = jumpLogService;
            _jumpService = jumpService;
        }
    
        [Authorize]
        [HttpGet("/jumplog")]
        public JumpLogDTO GetJumpLog()
        {
            return new JumpLogDTO(_jumpLogService.GetUserJumpLog());
        }

        [Authorize]
        [HttpGet("{id}")]
        public Jump Get(int jumpId)
        {
            return _jumpService.GetJump(jumpId);
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] JumpDTO jumpDTO)
        {
            _jumpService.AddJump(jumpDTO);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JumpDTO jumpDTO)
        {
            _jumpService.UpdateJump(id, jumpDTO);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _jumpService.DeleteJump(id);
        }
    }
}
