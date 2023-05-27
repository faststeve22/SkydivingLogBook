using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
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

        public AircraftDTO GetAircraft(int aircraftId)
        {
            return ConvertModelToDTO(_aircraftDAO.GetAircraftById(aircraftId));
        }
        
        public AircraftListDTO GetAircraftList()
        {
            return ConvertModelToDTO(_aircraftDAO.GetAircraftList());
        }

        public AircraftListDTO GetAircraftListByUserId(int userId)
        {
            return ConvertModelToDTO(_aircraftDAO.GetAircraftListByUserId(userId));
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

        private AircraftDTO ConvertModelToDTO(Aircraft model)
        {
            AircraftDTO dto = new AircraftDTO();
            dto.AircraftId = model.AircraftId;
            dto.AircraftName = model.AircraftName;
            return dto;
        }

        private AircraftListDTO ConvertModelToDTO(AircraftList model)
        {
            AircraftListDTO dto = new AircraftListDTO();
            dto.Aircraft = model.Aircraft;
            return dto;
        }

    }
}
