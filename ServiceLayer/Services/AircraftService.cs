using Logbook.DataAccessLayer.Interfaces;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftDAO _aircraftDAO;
        private readonly IUserService _userService;
        public AircraftService(IAircraftDAO aircraftDAO, IUserService userService)
        {
            _aircraftDAO = aircraftDAO;
            _userService = userService;
        }

        public AircraftDTO GetAircraftById(int aircraftId)
        {
            return _aircraftDAO.GetAircraftById(aircraftId);
        }
        
        public AircraftListDTO GetAircraftList()
        {
            return _aircraftDAO.GetAircraftList();
        }

        public AircraftListDTO GetAircraftListByUserId()
        {
            return _aircraftDAO.GetAircraftListByUserId(_userService.GetUserId());
        }
        public void AddAircraft(AircraftDTO dto)
        {
            _aircraftDAO.AddAircraft(dto);
        }

        public void UpdateAircraft(AircraftDTO dto)
        {
            _aircraftDAO.UpdateAircraft(dto);
        }

        public void DeleteAircraft(int aircraftId)
        {
            _aircraftDAO.DeleteAircraft(aircraftId);
        }
    }
}
