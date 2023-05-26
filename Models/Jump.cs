namespace Logbook.Models
{
    public class Jump
    {
       public int JumpId { get; set; }
       public int UserId { get; set; }
       public int WeatherId { get; set; }
       public int AircraftId { get; set; }
       public int EquipmentId { get; set; }
       public int DropzoneId { get; set; }
       public int JumpNumber { get; set; }
       public DateTime JumpDate { get; set; }
       public string JumpType { get; set; }
       public int ExitAltitude { get; set; }
       public string LandingPattern { get; set; }
       public string Notes { get; set; }
       public int TotalJumpers { get; set; }

        public Jump()
        {

        }
        public Jump(int jumpId, int userId, int weatherId, int aircraftId, int equipmentId, int dropzoneId, int jumpNumber, DateTime jumpDate, string jumpType, int exitAltitude, string landingPattern, string notes, int totalJumpers)
        {
            JumpId = jumpId;
            UserId = userId;
            WeatherId = weatherId;
            EquipmentId = equipmentId;
            DropzoneId = dropzoneId;
            JumpNumber = jumpNumber;
            JumpDate = jumpDate;
            JumpType = jumpType;
            ExitAltitude = exitAltitude;
            LandingPattern = landingPattern;
            Notes = notes;
            TotalJumpers = totalJumpers;
        }
    }
}
