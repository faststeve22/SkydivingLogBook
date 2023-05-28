using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IAircraftDAO
    {
        void AddAircraft(AircraftDTO dto);
        AircraftListDTO GetAircraftList();
        AircraftDTO GetAircraftById(int aircraftId);
        AircraftListDTO GetAircraftListByUserId(int userId);
        void UpdateAircraft(AircraftDTO dto);
        void DeleteAircraft(int aircraftId);

    }
}
