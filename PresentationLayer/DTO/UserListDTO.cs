using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class UserListDTO
    {
        public List<Jumper> Jumpers {get; set;}

        public UserListDTO()
        {

        }

        public UserListDTO(List<Jumper> jumpers)
        {
            Jumpers = jumpers;
        }

    }
}
