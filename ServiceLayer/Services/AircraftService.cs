using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
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
            return new AircraftDTO(_aircraftDAO.GetAircraftById(aircraftId));
        }
        
        public AircraftListDTO GetAircraftList()
        {
            return new AircraftListDTO(_aircraftDAO.GetAircraftList());
        }

        public AircraftListDTO GetAircraftListByUserId()
        {
            return new AircraftListDTO(_aircraftDAO.GetAircraftListByUserId(_userService.GetUserId()));
        }
        public void AddAircraft(AircraftDTO aircraftDTO)
        {
            Aircraft aircraft = new Aircraft(aircraftDTO);
            _aircraftDAO.AddAircraft(aircraft);
        }

        public void UpdateAircraft(AircraftDTO aircraftDTO)
        {
            Aircraft aircraft = new Aircraft(aircraftDTO);
            _aircraftDAO.UpdateAircraft(aircraft);
        }

        public void DeleteAircraft(int aircraftId)
        {
            _aircraftDAO.DeleteAircraft(aircraftId);
        }
    }
}
