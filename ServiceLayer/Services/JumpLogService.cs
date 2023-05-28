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
        private readonly IJumpService _jumpService;
        private readonly IWeatherService _weatherService;
        public JumpLogService(IAircraftService aircraftService, IUserService userService, IDropzoneService dropzoneService, IEquipmentService equipmentService, IJumpService jumpService, IWeatherService weatherService)
        {
            _aircraftService = aircraftService;
            _userService = userService;
            _dropzoneService = dropzoneService;
            _equipmentService = equipmentService;
            _jumpService = jumpService;
            _weatherService = weatherService;
        }

        public JumpLogDTO GetUserJumpLog()
        {
            JumpLog jumpLog = new JumpLog(GetJumpsByUserId(), GetAircraftByUserId(), GetDropzonesByUserId(), GetEquipmentByUserId(), GetWeatherListByUserId());
            return new JumpLogDTO(jumpLog);
        }

        public void DeleteJumpLog()
        {
            int userId = _userService.GetUserId();
            _equipmentService.DeleteEquipmentByUserId(userId);
            _weatherService.DeleteWeatherByUserId(userId);
            _jumpService.DeleteJumpsByUserId(userId);
        }

        private JumpList GetJumpsByUserId()
        {
            return new JumpList(_jumpService.GetJumpsByUserId());
        }

        private AircraftList GetAircraftByUserId()
        {
            return new AircraftList(_aircraftService.GetAircraftListByUserId());
        }

        private DropzoneList GetDropzonesByUserId()
        {
            return new DropzoneList(_dropzoneService.GetDropzoneListByUserId());
        }

        private EquipmentList GetEquipmentByUserId()
        {
            return new EquipmentList(_equipmentService.GetEquipmentListByUserId());
        }
        private WeatherList GetWeatherListByUserId()
        {
            return new WeatherList(_weatherService.GetWeatherListByUserId());
        }
    }
}
