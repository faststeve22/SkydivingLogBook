namespace Logbook.Models.Lists
{
    public class JumpList
    {
        List<Jump> Jumps { get; set; }

        public JumpList(List<Jump> jumps)
        {
            Jumps = jumps;
        }
    }
}
