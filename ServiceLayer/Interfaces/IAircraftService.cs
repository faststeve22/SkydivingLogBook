using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IAircraftService
    {
         AircraftDTO GetAircraftById(int aircraftId);
         AircraftListDTO GetAircraftList();
         AircraftListDTO GetAircraftListByUserId();


         AircraftDTO AddAircraft(AircraftDTO aircraftDTO);
         void UpdateAircraft(AircraftDTO aircraftDTO);
         void DeleteAircraft(int aircraftId);

    }
}
