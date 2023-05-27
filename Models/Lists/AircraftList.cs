using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class AircraftList
    {
        public List<Aircraft> Aircraft { get; set; }

        public AircraftList(List<Aircraft> aircraft)
        {
            Aircraft = aircraft;
        }
        
        public AircraftList(AircraftListDTO dto)
        {
            Aircraft = dto.Aircraft;
        }
    }
}
