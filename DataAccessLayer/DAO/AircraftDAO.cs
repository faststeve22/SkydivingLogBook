using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

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

        public AircraftDTO AddAircraft(AircraftDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Aircraft (aircraft_name) VALUES (@aircraftName)";
                    _daoUtilities.AddParameter(cmd, dto.AircraftName, "@aircraftName");
                    IDataReader reader = cmd.ExecuteReader();
                    return new AircraftDTO(_daoUtilities.MapDataToList<Aircraft>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new AircraftException("AddAircraft", ex);
{
                };
            }
        }

        public AircraftDTO GetAircraftById(int aircraftId)
        {
            try
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
            catch(SqlException ex)
            {
                throw new AircraftException("GetAircraftById", ex);
            }
        }

        public AircraftListDTO GetAircraftList()
        { 
            try
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
            catch(SqlException ex)
            {
                throw new AircraftException("GetAircraftList", ex);
            }
        }

        public AircraftListDTO GetAircraftListByUserId(int userId)
        {
            try 
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
            catch(SqlException ex)
            {
                throw new AircraftException("GetAircraftListByUserId", ex);
            }
        }

        public void UpdateAircraft(AircraftDTO dto)
        {
            try
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
            catch(SqlException ex)
            {
                throw new AircraftException("UpdateAircraft", ex);
            }
        }

        public void DeleteAircraft(int aircraftId)
        {
            try
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
            catch(SqlException ex)
            {
                throw new AircraftException("DeleteAircraft", ex);
            }
        }
    }
}
