using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftDAO _aircraftDAO;
        public AircraftService(IAircraftDAO aircraftDAO)
        {
            _aircraftDAO = aircraftDAO;
        }

        public Aircraft GetAircraft(int aircraftId)
        {
            return _aircraftDAO.GetAircraft(aircraftId);
        }

        public void AddAircraft(AircraftDTO aircraftDTO)
        {
            _aircraftDAO.AddAircraft(ConvertDTOToModel(aircraftDTO));
        }

        public void UpdateAircraft(AircraftDTO aircraftDTO)
        {
            _aircraftDAO.UpdateAircraft(ConvertDTOToModel(aircraftDTO));
        }

        public void DeleteAircraft(int aircraftId)
        {
            _aircraftDAO.DeleteAircraft(aircraftId);
        }
        private Aircraft ConvertDTOToModel(AircraftDTO aircraftDTO)
        {
            Aircraft aircraft = new Aircraft();
            if (aircraftDTO.AircraftId != 0)
            {
                aircraft.AircraftId = aircraftDTO.AircraftId;
            }
            aircraft.AircraftName = aircraftDTO.AircraftName;
            return aircraft;
        }

    }
}
