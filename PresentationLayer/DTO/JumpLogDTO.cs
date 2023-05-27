using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class JumpLogDTO
    {
        public JumpList Jumps { get; set; }
        public AircraftList Aircraft { get; set; }
        public DropzoneList Dropzones { get; set; }
        public EquipmentList Equipment { get; set; }
        public WeatherList Weather { get; set; }

        public JumpLogDTO() { }
        public JumpLogDTO(JumpLog jumpLog)
        {
            Jumps = jumpLog.Jumps;
            Aircraft = jumpLog.Aircraft;
            Dropzones = jumpLog.Dropzones;
            Equipment = jumpLog.Equipment;
            Weather = jumpLog.Weather;
        } 
    }
}
