using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class JumpService : IJumpService
    {
        private readonly IJumpDAO _jumpDAO;
        public JumpService(IJumpDAO jumpDAO, IHttpContextAccessor httpContextAccessor)
        {
            _jumpDAO = jumpDAO;
        }

        public void AddJump(JumpDTO jumpDTO)
        {
            _jumpDAO.AddJump(ConvertDTOToModel(jumpDTO));
        }
        public Jump GetJumpById(int jumpId)
        {
            return _jumpDAO.GetJumpById(jumpId);
        }

        public JumpList GetJumps()
        {
            return _jumpDAO.GetJumps();
        }

        public JumpList GetJumpsByUserId(int userId)
        {
            return _jumpDAO.GetJumpsByUserId(userId);
        }

        public void UpdateJump(JumpDTO jumpDTO)
        {
            _jumpDAO.UpdateJump(ConvertDTOToModel(jumpDTO));
        }

        public void DeleteJump(int jumpId)
        {
            _jumpDAO.DeleteJump(jumpId);
        }

        private Jump ConvertDTOToModel(JumpDTO jumpDTO)
        {
            Jump jump = new Jump();
            if(jump.JumpId != 0)
            {
                jump.JumpId = jumpDTO.JumpId;
            }
            jump.UserId = jumpDTO.UserId;
            jump.WeatherId = jumpDTO.WeatherId;
            jump.AircraftId = jumpDTO.AircraftId;
            jump.EquipmentId = jumpDTO.EquipmentId;
            jump.DropzoneId = jumpDTO.DropzoneId;
            jump.JumpNumber = jumpDTO.JumpNumber;
            jump.JumpDate = jumpDTO.JumpDate;
            jump.JumpType = jumpDTO.JumpType;
            jump.ExitAltitude = jumpDTO.ExitAltitude;
            jump.LandingPattern = jumpDTO.LandingPattern;
            jump.Notes = jumpDTO.Notes;
            jump.TotalJumpers = jumpDTO.TotalJumpers;
            return jump;
        }

    }
}
