using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class JumpListDTO
    {
        public List<Jump> Jumps { get; set; }

        public JumpListDTO()
        {
            Jumps = new List<Jump>();
        }

        public JumpListDTO(JumpList list)
        {
            Jumps = new List<Jump>();
            Jumps = list.Jumps;
        }

        public JumpListDTO(List<Jump> jumps)
        {
            Jumps = new List<Jump>();
            Jumps = jumps;
        }


    }
}
