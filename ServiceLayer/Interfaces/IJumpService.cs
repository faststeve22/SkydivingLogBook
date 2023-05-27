using Logbook.Models;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpService
    {
        public void AddJump(JumpDTO jump);

        public Jump GetJump(int jumpId);

        public void UpdateJump(int jumpId, JumpDTO jump);
        public void DeleteJump(int jumpId);

    }
}
