using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpService
    {
        public void AddJump(JumpDTO jump);

        public JumpDTO GetJumpById(int jumpId);

        public JumpListDTO GetJumps();

        public JumpListDTO GetJumpsByUserId(int userId);

        public void UpdateJump(JumpDTO dto);
        public void DeleteJump(int jumpId);
        public void DeleteJumpsByUserId(int userId);

    }
}
