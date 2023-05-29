using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class AircraftDAO : IAircraftDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IDaoUtilities _daoUtilities;
        public AircraftDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }

        public void AddAircraft(AircraftDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Aircraft (aircraft_name) VALUES (@aircraftName)";
                _daoUtilities.AddParameter(cmd, dto.AircraftName, "@aircraftName");
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
                _daoUtilities.AddParameter(cmd, aircraftId, "aircraftId");
                IDataReader reader = cmd.ExecuteReader();
                return new AircraftDTO(_daoUtilities.MapDataToList<Aircraft>(reader)[0]);
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
                return new AircraftListDTO(_daoUtilities.MapDataToList<Aircraft>(reader));
            }
        }

        public AircraftListDTO GetAircraftListByUserId(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Aircraft.aircraft_id, aircraft_name FROM Aircraft JOIN Jump ON Jump.aircraft_id = Aircraft.aircraft_id WHERE Jump.user_id = @userId";
                _daoUtilities.AddParameter(cmd, userId, "@userId");
                IDataReader reader = cmd.ExecuteReader();
                return new AircraftListDTO(_daoUtilities.MapDataToList<Aircraft>(reader));
            }
        }

        public void UpdateAircraft(AircraftDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Aircraft SET aircraft_name = @aircraftName WHERE aircraft_id = @aircraftId";
                _daoUtilities.AddParameter(cmd, dto);
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
                _daoUtilities.AddParameter(cmd, aircraftId, "@aircraftId");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
