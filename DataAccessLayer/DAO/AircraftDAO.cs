using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
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
                return AircraftReader(reader)[0];
            }
        }

        public AircraftList GetAircraftList(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELET aircraft_id, aircraft_name FROM Aircraft JOIN Jump ON Jump.aircraft_id = Aircraft.aircraft_id WHERE Jump.user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return new AircraftList(AircraftReader(reader));
            }
        }

        public void UpdateAircraft(Aircraft aircraft)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Aircraft SET aircraft_name = @aircraftName WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", aircraft.AircraftId);
                AddParameter(cmd, "@aircraftName", aircraft.AircraftName);
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

        private List<Aircraft> AircraftReader(IDataReader reader)
        {
            List<Aircraft> AircraftList = new List<Aircraft>();
            while(reader.Read())
            {
                Aircraft aircraft = new Aircraft();
                aircraft.AircraftId = Convert.ToInt32(reader["aircraft_id"]);
                aircraft.AircraftName = Convert.ToString(reader["aircraft_name"]);
                AircraftList.Add(aircraft);
            }
            return AircraftList;
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
