using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IJumpService
    {
         JumpDTO AddJump(JumpDTO jump);

         JumpDTO GetJumpById(int jumpId);

         JumpListDTO GetJumps();

         JumpListDTO GetJumpsByUserId();

         void UpdateJump(JumpDTO dto);
         void DeleteJump(int jumpId);
         void DeleteJumpsByUserId();

    }
}
