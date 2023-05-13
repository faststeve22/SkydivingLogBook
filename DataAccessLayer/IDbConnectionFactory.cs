using System.Data;

namespace Logbook.DataAccessLayer
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
