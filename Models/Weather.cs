namespace Logbook.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public string GroundTemperature { get; set; }
        public string GroundWindSpeed { get; set; }
        public string GroundWindDirectionAtTakeoff { get; set; }
        public string GroundWindDirectionAtLanding { get; set; }
        public int TemperatureAtJumpAltitude { get; set; }
        public string Notes { get; set; }

    }
}
