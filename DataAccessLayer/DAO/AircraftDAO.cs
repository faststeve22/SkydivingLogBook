using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class AircraftDAO : IAircraftDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public AircraftDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddAircraft(Aircraft aircraft)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Aircraft (aircraft_id, aircraft_name) VALUES (@aircraftId, @aircraftName)";
                AddParameter(cmd, "@aircraftId", aircraft.AircraftId);
                AddParameter(cmd, "@aircraftName", aircraft.AircraftName);
                cmd.ExecuteNonQuery();
            }
        }

        public Aircraft GetAircraft(int aircraftId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELET aircraft_id, aircraft_name FROM Aircraft WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", aircraftId);
                IDataReader reader = cmd.ExecuteReader();
                return AircraftReader(reader);
            }
        }

        public void UpdateAircraft(int aircraftId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Aircraft SET aircraft_name = @aircraftName WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", aircraftId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAircraft(int aircraftId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Aircraft WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", aircraftId);
                cmd.ExecuteNonQuery();
            }
        }

        private Aircraft AircraftReader(IDataReader reader)
        {
            Aircraft aircraft = new Aircraft();
            aircraft.AircraftId = Convert.ToInt32(reader["aircraft_id"]);
            aircraft.AircraftName = Convert.ToString(reader["aircraft_name"]);
            return aircraft;
        }

        private void AddParameter(IDbCommand cmd, string parameterName, object value)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = parameterName;
            Parameter.Value = value;
            cmd.Parameters.Add(Parameter);
        }

    }
}
