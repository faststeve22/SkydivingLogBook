using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class AircraftDAO : IAircraftDAO
    { 
        private readonly IDbConnectionFactory _connectionFactory;
        public AircraftDAO(IDbConnectionFactory connectionFactory) 
        { 
            _connectionFactory = connectionFactory;
        }

    }
}
