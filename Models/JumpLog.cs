using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.Models
{
    public class JumpLog
    {
        public List<Jump> Jumps { get; set; }
        public List<Aircraft> Aircraft { get; set; }
        public List<Dropzone> Dropzones { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<Weather> Weather { get; set; }

        public JumpLog(List<Jump> jumps, List<Aircraft> aircraft, List<Dropzone> dropzones, List<Equipment> equipment, List<Weather> weather)
        {
            Jumps = jumps;
            Aircraft = aircraft;
            Dropzones = dropzones;
            Equipment = equipment;
            Weather = weather;
        }
    }
}
