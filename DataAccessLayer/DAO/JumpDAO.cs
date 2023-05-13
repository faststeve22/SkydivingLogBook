using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class JumpDAO : IJumpDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public JumpDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
