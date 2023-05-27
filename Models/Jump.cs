using Logbook.PresentationLayer.DTO;
using Microsoft.AspNetCore.Components;

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
        
        public Jump(JumpDTO dto)
        {
            JumpId = dto.JumpId;
            UserId = dto.UserId;
            WeatherId = dto.WeatherId;
            AircraftId = dto.AircraftId;
            EquipmentId = dto.EquipmentId;
            DropzoneId = dto.DropzoneId;
            JumpNumber = dto.JumpNumber;
            JumpDate = dto.JumpDate;
            JumpType = dto.JumpType;
            ExitAltitude = dto.ExitAltitude;
            LandingPattern = dto.LandingPattern;
            Notes = dto.Notes;
            TotalJumpers = dto.TotalJumpers;
        }
    }
}
