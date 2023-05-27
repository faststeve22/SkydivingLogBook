using Logbook.Models;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IAircraftService
    {
        public Aircraft GetAircraft(int aircraftId);
        public void AddAircraft(AircraftDTO aircraftDTO);
        public void UpdateAircraft(AircraftDTO aircraftDTO);
        public void DeleteAircraft(int aircraftId);
    }
}
