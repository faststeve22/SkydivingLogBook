using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Logbook.DataAccessLayer.DAO
{
    public class JumpDAO : IJumpDAO
    {
        IDbConnectionFactory _connectionFactory;
        IDaoUtilities _daoUtilities;
        public JumpDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }
        public void AddJump(JumpDTO dto)
        {
            try
            {
                Type type = typeof(JumpDTO);
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Jump (user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers) VALUES (@userId, @weatherId, @aircraftId, @equipmentId, @dropzoneId, @jumpNumber, @jumpDate, @jumpType, @exitAltitude, @landingPattern, @notes, @totalJumpers)";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("AddJump", ex);
            }
        }

        public JumpDTO GetJumpById(int jumpId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE jump_id = @jumpId";
                    _daoUtilities.AddParameter(cmd, jumpId, "@jumpId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new JumpDTO(_daoUtilities.MapDataToList<Jump>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("GetJumpById", ex);
            }
        }

        public JumpListDTO GetJumps()
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump";
                    IDataReader reader = cmd.ExecuteReader();
                    return new JumpListDTO(_daoUtilities.MapDataToList<Jump>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("GetJumps", ex);
            }
        }
        public JumpListDTO GetJumpsByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new JumpListDTO(_daoUtilities.MapDataToList<Jump>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("GetJumpsByUserId", ex;
            }
        }

        public void UpdateJump(JumpDTO dto)
        {
            try
            {
                Type type = typeof(JumpDTO);
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Jump SET user_id = @userId, weather_id = @weatherId, aircraft_id = @aircraftId, equipment_id = @equipmentId, dropzone_id = @dropzoneId, jump_number = @jumpNumber, jump_date = @jumpDate, jump_type = @jumpType, exit_altitude = @exitAltitude, landing_pattern = @landingPattern, notes = @notes, total_jumpers = @totalJumpers WHERE jump_id = @jumpId";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("UpdateJump", ex);
            }
        }

        public void DeleteJump(int jumpId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Jump WHERE jump_id = @jumpId";
                    _daoUtilities.AddParameter(cmd, jumpId, "@jumpId");
                     cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("DeleteJump", ex);
            }
        }

        public void DeleteJumpsByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Jump WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new JumpException("DeleteJumpsByUserId", ex);
            }
        }
    }
}
