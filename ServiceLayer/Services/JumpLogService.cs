using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;

namespace Logbook.ServiceLayer.Services
{
    public class JumpLogService
    {
        private readonly IAircraftDAO aircraftDAO;
        private readonly IDropzoneDAO dropzoneDAO;
        private readonly IEquipmentDAO equipmentDAO;
        private readonly IJumpDAO jumpDAO;
        private readonly IDbUserDAO userDAO;
        private readonly IWeatherDAO weatherDAO;
        public JumpLog GetJumpLog(int userId)
        {

        }

        
    }
}
