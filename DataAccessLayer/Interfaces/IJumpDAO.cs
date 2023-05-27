using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IJumpDAO
    {
        public void AddJump(Jump jump);
        public Jump GetJumpById(int jumpId);
        public JumpList GetJumps();
        public JumpList GetJumpsByUserId(int userId);
        public void UpdateJump(Jump jump);
        public void DeleteJump(int jumpId);


    }
}
