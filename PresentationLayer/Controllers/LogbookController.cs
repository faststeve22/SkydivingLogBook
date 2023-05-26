using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Logbook.PresentationLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LogbookController : ControllerBase
    {
        private readonly IJumpLogService _jumpLogService;

        public LogbookController(IJumpLogService jumpLogService)
        {
            _jumpLogService = jumpLogService;
        }
    
        [Authorize]
        [HttpGet]
        public JumpLogDTO GetJumpLog()
        {
            return new JumpLogDTO(_jumpLogService.GetUserJumpLog());
        }

     /*   [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
