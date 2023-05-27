using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class AircraftDTO
    {
        public int AircraftId { get; set; }
        public string AircraftName { get; set; }

        public AircraftDTO()
        {

        }

        public AircraftDTO(Aircraft aircraft)
        {
            AircraftId = aircraft.AircraftId;
            AircraftName = aircraft.AircraftName;
        }
    }
}
