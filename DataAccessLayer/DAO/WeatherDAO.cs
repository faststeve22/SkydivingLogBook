using Logbook.DataAccessLayer.Interfaces;

namespace Logbook.DataAccessLayer.DAO
{
    public class WeatherDAO : IWeatherDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public WeatherDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
