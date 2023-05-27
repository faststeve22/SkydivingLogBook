using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IAircraftDAO
    {
        public void AddAircraft(Aircraft aircraft);
        public AircraftList GetAircraftList();
        public Aircraft GetAircraftById(int aircraftId);
        public AircraftList GetAircraftListByUserId(int userId);
        public void UpdateAircraft(Aircraft aircraft);
        public void DeleteAircraft(int aircraftId);

    }
}
