using Logbook.DataAccessLayer.Interfaces;
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

        public JumpDTO AddJump(JumpDTO dto)
        {
            dto.UserId = _userService.GetUserId();
            return _jumpDAO.AddJump(dto);
        }
        public JumpDTO GetJumpById(int jumpId)
        {
            return _jumpDAO.GetJumpById(jumpId);
        }

        public JumpListDTO GetJumps()
        {
            return _jumpDAO.GetJumps();
        }

        public JumpListDTO GetJumpsByUserId()
        {
            return _jumpDAO.GetJumpsByUserId(_userService.GetUserId());
        }

        public void UpdateJump(JumpDTO dto)
        {
            _jumpDAO.UpdateJump(dto);
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
