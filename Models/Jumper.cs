using Logbook.PresentationLayer.DTO;

namespace Logbook.Models
{
    public class Jumper
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public Jumper()
        {

        }
        public Jumper(UserDTO dto)
        {
            UserId = dto.UserId;
            Username = dto.Username;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            EmailAddress = dto.EmailAddress;
        }
    }
}
