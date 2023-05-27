using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class JumpListDTO
    {
       public List<Jump> Jumps { get; set; }

        public JumpListDTO()
        {

        }

        public JumpListDTO(JumpList list)
        {
            Jumps = list.Jumps;
        }
    }
}
