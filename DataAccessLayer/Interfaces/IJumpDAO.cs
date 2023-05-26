using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IJumpDAO
    {
        public void AddJump(Jump jump);
        public Jump GetJump(int jumpId);
        public JumpList GetAllJumps(int userId);
        public void UpdateJump(Jump jump);
        public void DeleteJump(int jumpId);


    }
}
