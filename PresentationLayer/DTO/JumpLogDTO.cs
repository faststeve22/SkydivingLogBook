using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class JumpLogDTO
    {
        public List<Jump> JumpLog { get; set; }

        public JumpLogDTO(List<Jump> jumpLog)
        {
            JumpLog = jumpLog;
        }
    }
}
