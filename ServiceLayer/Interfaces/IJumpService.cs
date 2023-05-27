using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpService
    {
        public void AddJump(JumpDTO jump);

        public Jump GetJumpById(int jumpId);

        public JumpList GetJumps();

        public JumpList GetJumpsByUserId(int userId);

        public void UpdateJump(JumpDTO dto);
        public void DeleteJump(int jumpId);
    }
}
