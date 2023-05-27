using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class JumpService : IJumpService
    {
        private readonly IJumpDAO _jumpDAO;
        public JumpService(IJumpDAO jumpDAO)
        {
            _jumpDAO = jumpDAO;
        }

        public void AddJump(JumpDTO jumpDTO)
        {
            Jump jump = new Jump(jumpDTO);
            _jumpDAO.AddJump(jump);
        }
        public JumpDTO GetJumpById(int jumpId)
        {
            return new JumpDTO(_jumpDAO.GetJumpById(jumpId));
        }

        public JumpListDTO GetJumps()
        {
            return new JumpListDTO(_jumpDAO.GetJumps());
        }

        public JumpListDTO GetJumpsByUserId(int userId)
        {
            return new JumpListDTO(_jumpDAO.GetJumpsByUserId(userId));
        }

        public void UpdateJump(JumpDTO jumpDTO)
        {
            Jump jump = new Jump(jumpDTO);
            _jumpDAO.UpdateJump(jump);
        }

        public void DeleteJump(int jumpId)
        {
            _jumpDAO.DeleteJump(jumpId);
        }

        public void DeleteJumpsByUserId(int userId)
        {
            _jumpDAO.DeleteJumpsByUserId(userId);
        }
    }
}
