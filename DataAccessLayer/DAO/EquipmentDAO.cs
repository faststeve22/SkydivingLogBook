using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class EquipmentDAO : IEquipmentDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public EquipmentDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
