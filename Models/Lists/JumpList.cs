using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class JumpList
    {
        public List<Jump> Jumps { get; set; }

        public JumpList(List<Jump> jumps)
        {
            Jumps = jumps;
        }

        public JumpList(JumpListDTO dto)
        {
            Jumps = dto.Jumps;
        }
    }
}
