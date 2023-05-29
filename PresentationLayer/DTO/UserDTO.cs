using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(Jumper jumper)
        {
            UserId = jumper.UserId;
            Username = jumper.Username;
            FirstName = jumper.FirstName;
            LastName = jumper.LastName;
            EmailAddress = jumper.EmailAddress;
        }
    }
}
