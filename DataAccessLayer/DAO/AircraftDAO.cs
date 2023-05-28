using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
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

        public void AddAircraft(AircraftDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Aircraft (aircraft_id, aircraft_name) VALUES (@aircraftId, @aircraftName)";
                AddParameter(cmd, "@aircraftName", dto.AircraftName);
                cmd.ExecuteNonQuery();
            }
        }

        public AircraftDTO GetAircraftById(int aircraftId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT aircraft_id, aircraft_name FROM Aircraft WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", aircraftId);
                IDataReader reader = cmd.ExecuteReader();
                return new AircraftDTO(AircraftReader(reader).Aircraft[0]);
            }
        }

        public AircraftListDTO GetAircraftList()
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT aircraft_id, aircraft_name FROM Aircraft";
                IDataReader reader = cmd.ExecuteReader();
                return AircraftReader(reader);
            }
        }

        public AircraftListDTO GetAircraftListByUserId(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Aircraft.aircraft_id, aircraft_name FROM Aircraft JOIN Jump ON Jump.aircraft_id = Aircraft.aircraft_id WHERE Jump.user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return AircraftReader(reader);
            }
        }

        public void UpdateAircraft(AircraftDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Aircraft SET aircraft_name = @aircraftName WHERE aircraft_id = @aircraftId";
                AddParameter(cmd, "@aircraftId", dto.AircraftId);
                AddParameter(cmd, "@aircraftName", dto.AircraftName);
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

        private AircraftListDTO AircraftReader(IDataReader reader)
        {
            AircraftListDTO dto = new AircraftListDTO();
            while(reader.Read())
            {
                Aircraft aircraft = new Aircraft();
                aircraft.AircraftId = Convert.ToInt32(reader["aircraft_id"]);
                aircraft.AircraftName = Convert.ToString(reader["aircraft_name"]);
                dto.Aircraft.Add(aircraft);
            }
            return dto;
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
