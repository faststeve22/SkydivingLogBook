using Logbook.Models.Lists;

namespace Logbook.Models
{
    public class JumpLog
    {
        public JumpList Jumps { get; set; }
        public AircraftList Aircraft { get; set; }
        public DropzoneList Dropzones { get; set; }
        public EquipmentList Equipment { get; set; }
        public WeatherList Weather { get; set; }

        public JumpLog(JumpList jumps, AircraftList aircraft, DropzoneList dropzones, EquipmentList equipment, WeatherList weather)
        {
            Jumps = jumps;
            Aircraft = aircraft;
            Dropzones = dropzones;
            Equipment = equipment;
            Weather = weather;
        }
    }
}
