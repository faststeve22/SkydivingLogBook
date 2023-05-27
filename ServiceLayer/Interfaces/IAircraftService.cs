using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IAircraftService
    {
        public Aircraft GetAircraft(int aircraftId);
        public AircraftList GetAircraftList();
        public AircraftList GetAircraftListByUserId(int userId);


        public void AddAircraft(AircraftDTO aircraftDTO);
        public void UpdateAircraft(AircraftDTO aircraftDTO);
        public void DeleteAircraft(int aircraftId);
    }
}
