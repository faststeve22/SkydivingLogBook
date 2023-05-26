using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IAircraftDAO
    {
        public void AddAircraft(Aircraft aircraft);
        public Aircraft GetAircraft(int aircraftId);
        public AircraftList GetAircraftList(int userId);
        public void UpdateAircraft(Aircraft aircraft);
        public void DeleteAircraft(int aircraftId);





    }
}
