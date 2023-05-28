using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class JumpService : IJumpService
    {
        private readonly IJumpDAO _jumpDAO;
        private readonly IUserService _userService;
        public JumpService(IJumpDAO jumpDAO, IUserService userService)
        {
            _jumpDAO = jumpDAO;
            _userService = userService;
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

        public JumpListDTO GetJumpsByUserId()
        {
            return new JumpListDTO(_jumpDAO.GetJumpsByUserId(_userService.GetUserId()));
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

        public void DeleteJumpsByUserId()
        {
            _jumpDAO.DeleteJumpsByUserId(_userService.GetUserId());
        }
    }
}
