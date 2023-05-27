using Logbook.PresentationLayer.DTO;

namespace Logbook.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string AircraftName { get; set; }

        public Aircraft()
        {

        }

        public Aircraft(AircraftDTO dto)
        {
            AircraftId = dto.AircraftId;
            AircraftName = dto.AircraftName;
        }

    }
}
