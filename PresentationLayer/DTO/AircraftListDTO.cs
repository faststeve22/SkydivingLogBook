using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class AircraftListDTO
    {
        public List<Aircraft> Aircraft { get; set; }

        public AircraftListDTO()
        {

        }

        public AircraftListDTO(List<Aircraft> aircraft)
        {
            Aircraft = aircraft;
        }

        public AircraftListDTO(AircraftList list)
        {
            Aircraft = list.Aircraft;
        }
    }
}
