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
            int userId = _userService.GetUserId();
            JumpLog jumpLog = new JumpLog(GetJumpsByUserId(userId), GetAircraftByUserId(userId), GetDropzonesByUserId(userId), GetEquipmentByUserId(userId), GetWeatherListByUserId(userId));
            return new JumpLogDTO(jumpLog);
        }

       //  public void DeleteJumpLog()

        private JumpList GetJumpsByUserId(int userId)
        {
            return new JumpList(_jumpService.GetJumpsByUserId(userId));
        }

        private AircraftList GetAircraftByUserId(int userId)
        {
            return new AircraftList(_aircraftService.GetAircraftListByUserId(userId));
        }
       
        private DropzoneList GetDropzonesByUserId(int userId)
        {
            return new DropzoneList(_dropzoneService.GetDropzoneListByUserId(userId));
        }

        private EquipmentList GetEquipmentByUserId(int userId)
        {
            return new EquipmentList(_equipmentService.GetEquipmentListByUserId(userId));
        }
        private WeatherList GetWeatherListByUserId(int userId)
        {
            return new WeatherList(_weatherService.GetWeatherListByUserId(userId));
        }
    }
}
