using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class JumpList
    {
        public List<Jump> Jumps { get; set; }

        public JumpList()
        {
            Jumps = new List<Jump>();
        }
        public JumpList(List<Jump> jumps)
        {
            Jumps = new List<Jump>();
            Jumps = jumps;
        }

        public JumpList(JumpListDTO dto)
        {
            Jumps = new List<Jump>();
            Jumps = dto.Jumps;
        }
    }
}
