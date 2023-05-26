using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.ServiceLayer.Services
{
    public class JumpLogService
    {
        private readonly IAircraftDAO _aircraftDAO;
        private readonly IDropzoneDAO _dropzoneDAO;
        private readonly IEquipmentDAO _equipmentDAO;
        private readonly IJumpDAO _jumpDAO;
        private readonly IDbUserDAO _userDAO;
        private readonly IWeatherDAO _weatherDAO;

        public JumpLogService(IAircraftDAO aircraftDAO, IDropzoneDAO dropzoneDAO, IEquipmentDAO equipmentDAO, IJumpDAO jumpDAO, IDbUserDAO userDAO, IWeatherDAO weatherDAO)
        {
            _aircraftDAO = aircraftDAO;
            _dropzoneDAO = dropzoneDAO;
            _equipmentDAO = equipmentDAO;
            _jumpDAO = jumpDAO;
            _userDAO = userDAO;
            _weatherDAO = weatherDAO;
        }

        public JumpLog GetUserJumpLog(int userId)
        {
            return new JumpLog(GetJumpsByUserId(userId), GetAircraftByUserId(userId), GetDropzonesByUserId(userId), GetEquipmentByUserId(userId), GetWeatherListByUserId(userId));
        }
        public JumpList GetJumpsByUserId(int userId)
        {
            return _jumpDAO.GetAllJumps(userId);
        }

        public AircraftList GetAircraftByUserId(int userId)
        {
            return _aircraftDAO.GetAircraftList(userId);
        }
       
        public DropzoneList GetDropzonesByUserId(int userId)
        {
            return _dropzoneDAO.GetDropzoneList(userId);
        }

        public EquipmentList GetEquipmentByUserId(int userId)
        {
            return _equipmentDAO.GetEquipmentList(userId);
        }
        public WeatherList GetWeatherListByUserId(int userId)
        {
            return _weatherDAO.GetWeatherList(userId);
        }
    }
}
