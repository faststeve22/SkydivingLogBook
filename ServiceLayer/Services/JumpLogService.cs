using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class JumpLogService : IJumpLogService
    {
        private readonly IAircraftService _aircraftService;
        private readonly IUserService _userService;
        private readonly IDropzoneService _dropzoneService;
        private readonly IEquipmentService _equipmentService;
        private readonly IJumpDAO _jumpDAO;
        private readonly IWeatherDAO _weatherDAO;
        public JumpLogService(IAircraftService aircraftService, IUserService userService, IDropzoneService dropzoneService, IEquipmentService equipmentService, IJumpDAO jumpDAO, IDbUserDAO userDAO, IWeatherDAO weatherDAO)
        {
            _aircraftService = aircraftService;
            _userService = userService;
            _dropzoneService = dropzoneService;
            _equipmentService = equipmentService;
            _jumpDAO = jumpDAO;
            _weatherDAO = weatherDAO;
        }

        public JumpLogDTO GetUserJumpLog()
        {
            int userId = _userService.GetUserId();
            JumpLog jumpLog = new JumpLog(GetJumpsByUserId(userId), GetAircraftByUserId(userId), GetDropzonesByUserId(userId), GetEquipmentByUserId(userId), GetWeatherListByUserId(userId));
            return ConvertModelToDTO(jumpLog);
        }
        public JumpList GetJumpsByUserId(int userId)
        {
            return _jumpDAO.GetAllJumps(userId);
        }

        public AircraftList GetAircraftByUserId(int userId)
        {
            return _aircraftService.GetAircraftListByUserId(userId);
        }
       
        public DropzoneList GetDropzonesByUserId(int userId)
        {
            return _dropzoneService.GetDropzoneListByUserId(userId);
        }

        public EquipmentList GetEquipmentByUserId(int userId)
        {
            return _equipmentService.GetEquipmentListByUserId(userId);
        }
        public WeatherList GetWeatherListByUserId(int userId)
        {
            return _weatherDAO.GetWeatherList(userId);
        }

        private JumpLogDTO ConvertModelToDTO(JumpLog jumpLog)
        {
            JumpLogDTO dto = new JumpLogDTO();
            dto.Jumps = jumpLog.Jumps;
            dto.Aircraft = jumpLog.Aircraft;
            dto.Dropzones = jumpLog.Dropzones;
            dto.Equipment = jumpLog.Equipment;
            dto.Weather = jumpLog.Weather;
            return dto;
        }
    }
}
