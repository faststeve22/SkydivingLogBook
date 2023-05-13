using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class DropzoneDAO : IDropzoneDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public DropzoneDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
