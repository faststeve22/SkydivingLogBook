namespace Logbook.Models
{
    public class Jumps
    {
        List<Jump> JumpList { get; set; } 

        public Jumps(List<Jump> jumpList)
        {
            JumpList = jumpList;
        }
    }
}
