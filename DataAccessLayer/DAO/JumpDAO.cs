using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;

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

        public JumpDTO GetJumpById(int jumpId)
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

        public JumpListDTO GetJumps()
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
        public JumpListDTO GetJumpsByUserId(int userId)
        {   using (IDbConnection conn = _connectionFactory.CreateConnection()) 
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE user_id = @userId";
                _daoUtilities.AddParameter(cmd, userId, "@userId");
                IDataReader reader = cmd.ExecuteReader();
                return new JumpListDTO(_daoUtilities.MapDataToList<Jump>(reader));
            }
        }

        public void UpdateJump(JumpDTO dto)
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

            public void DeleteJump(int jumpId)
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

            public void DeleteJumpsByUserId(int userId)
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
    }
}
