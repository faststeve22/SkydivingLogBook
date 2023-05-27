using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpLogService
    {
        public JumpLogDTO GetUserJumpLog();
        public void DeleteJumpLog(int userId);

    }
}
