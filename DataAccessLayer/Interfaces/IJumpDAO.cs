using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IJumpDAO
    {
        JumpDTO AddJump(JumpDTO dto);
        JumpDTO GetJumpById(int jumpId);
        JumpListDTO GetJumps();
        JumpListDTO GetJumpsByUserId(int userId);
        void UpdateJump(JumpDTO dto);
        void DeleteJump(int jumpId);
        void DeleteJumpsByUserId(int userId);

    }
}
