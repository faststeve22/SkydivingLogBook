namespace Logbook.Models
{
    public class JumpLog
    {
        public List<Jump> Log { get; set; }

        public JumpLog(List<Jump> log)
        {
            Log = log;
        }
    }
}
