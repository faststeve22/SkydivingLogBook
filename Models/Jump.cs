namespace Logbook.Models
{
    public class Jump
    {
        int JumpId { get; set; }
        int UserId { get; set; }
        int WeatherId { get; set; }
        int AircraftId { get; set; }
        int EquipmentId { get; set; }
        int DropzoneId { get; set; }
        int JumpNumber { get; set; }
        DateTime JumpDate { get; set; }
        string JumpType { get; set; }
        int ExitAltitude { get; set; }
        string LandingPattern { get; set; }
        string Notes { get; set; }
        int TotalJumpers { get; set; }

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
