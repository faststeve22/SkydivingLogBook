using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IAircraftService
    {
        public AircraftDTO GetAircraftById(int aircraftId);
        public AircraftListDTO GetAircraftList();
        public AircraftListDTO GetAircraftListByUserId(int userId);


        public void AddAircraft(AircraftDTO aircraftDTO);
        public void UpdateAircraft(AircraftDTO aircraftDTO);
        public void DeleteAircraft(int aircraftId);

    }
}
