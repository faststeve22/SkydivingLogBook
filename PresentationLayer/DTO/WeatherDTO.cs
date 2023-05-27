using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class WeatherDTO
    {
        public int WeatherId { get; set; }
        public string GroundTemperature { get; set; }
        public string GroundWindSpeed { get; set; }
        public string GroundWindDirectionAtTakeoff { get; set; }
        public string GroundWindDirectionAtLanding { get; set; }
        public int TemperatureAtJumpAltitude { get; set; }
        public string Notes { get; set; }

        public WeatherDTO()
        {

        }
        
        public WeatherDTO(Weather weather)
        {
            WeatherId = weather.WeatherId;
            GroundTemperature = weather.GroundTemperature;
            GroundWindSpeed = weather.GroundWindSpeed;
            GroundWindDirectionAtTakeoff = weather.GroundWindDirectionAtTakeoff;
            GroundWindDirectionAtLanding = weather.GroundWindDirectionAtLanding;
            TemperatureAtJumpAltitude = weather.TemperatureAtJumpAltitude;
            Notes = weather.Notes;
        }

    }
}
