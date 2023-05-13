namespace Logbook.DataAccessLayer.DatabaseEntities
{
    public class DBOJump
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
    }
}
