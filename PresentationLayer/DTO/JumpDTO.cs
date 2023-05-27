using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class JumpDTO
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

       public JumpDTO()
       {

       }

        public JumpDTO(Jump jump)
        {
            JumpId = jump.JumpId;
            UserId = jump.UserId;
            WeatherId = jump.WeatherId;
            AircraftId = jump.AircraftId;
            EquipmentId = jump.EquipmentId;
            DropzoneId = jump.DropzoneId;
            JumpNumber = jump.JumpNumber;
            JumpDate = jump.JumpDate;
            JumpType = jump.JumpType;
            ExitAltitude = jump.ExitAltitude;
            LandingPattern = jump.LandingPattern;
            Notes = jump.Notes;
            TotalJumpers = jump.TotalJumpers;
        }
    }
}
