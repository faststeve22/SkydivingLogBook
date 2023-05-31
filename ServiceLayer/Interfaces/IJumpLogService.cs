using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpLogService
    {
         JumpLogDTO GetUserJumpLog();
         void DeleteJumpLog();

    }
}
