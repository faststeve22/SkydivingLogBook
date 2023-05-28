using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logbook.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JumpLogController : ControllerBase
    {
        private readonly IJumpLogService _jumpLogService;

        public JumpLogController(IJumpLogService jumpLogService)
        {
            _jumpLogService = jumpLogService;
        }

        [Authorize]
        [HttpGet]
        public JumpLogDTO GetJumpLog()
        {
            return _jumpLogService.GetUserJumpLog();
        }

        [Authorize]
        [HttpDelete]
        public void Delete()
        {
            _jumpLogService.DeleteJumpLog();
        }
    }
}
