using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class DbUserDAO : IDbUserDAO
    {
        IDbConnectionFactory _connectionFactory;

        public DbUserDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
