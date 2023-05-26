namespace Logbook.Models.Lists
{
    public class AircraftList
    {
        public List<Aircraft> Aircraft { get; set; }

        public AircraftList(List<Aircraft> aircraft)
        {
            Aircraft = aircraft;
        }
    }
}
