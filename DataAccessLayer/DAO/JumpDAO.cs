using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class JumpDAO : IJumpDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public JumpDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void AddJump(JumpDTO dto)
        {
            Type type = typeof(JumpDTO);
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Jump (user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers) VALUES (@userId, @weatherId, @aircraftId, @equipmentId, @dropzoneId, @jumpNumber, @jumpDate, @jumpType, @exitAltitude, @landingPattern, @notes, @totalJumpers)";
                foreach(var prop in type.GetProperties())
                {
                    if(prop.Name != "JumpId")
                    {
                        AddParameter(cmd, prop.Name, prop);
                    }
                }
             /* AddParameter(cmd, "@userId", dto.UserId);
                AddParameter(cmd, "@weatherId", dto.WeatherId);
                AddParameter(cmd, "@aircraftId", dto.AircraftId);
                AddParameter(cmd, "@equipmentId", dto.EquipmentId);
                AddParameter(cmd, "@dropzoneId", dto.DropzoneId);
                AddParameter(cmd, "@jumpNumber", dto.JumpNumber);
                AddParameter(cmd, "@jumpDate", dto.JumpDate);
                AddParameter(cmd, "@jumpType", dto.JumpType);
                AddParameter(cmd, "@exitAltitude", dto.ExitAltitude);
                AddParameter(cmd, "@landingPattern", dto.LandingPattern);
                AddParameter(cmd, "@notes", dto.Notes);
                AddParameter(cmd, "@totalJumpers", dto.TotalJumpers);
                cmd.ExecuteNonQuery(); */
            }
        }

        public JumpDTO GetJumpById(int jumpId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE jump_id = @jumpId";
                AddParameter(cmd, "@jumpId", jumpId);
                IDataReader reader = cmd.ExecuteReader();
                return new JumpDTO(JumpReader(reader).Jumps[0]);
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
                return JumpReader(reader);
            }
        }
        public JumpListDTO GetJumpsByUserId(int userId)
        {   using (IDbConnection conn = _connectionFactory.CreateConnection()) 
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return JumpReader(reader);
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
                foreach (var prop in type.GetProperties())
                {
                   AddParameter(cmd, prop.Name, prop);
                }

            /*  AddParameter(cmd, "@jumpId", dto.JumpId);
                AddParameter(cmd, "@userId", dto.UserId);
                AddParameter(cmd, "@weatherId", dto.WeatherId);
                AddParameter(cmd, "@aircraftId", dto.AircraftId);
                AddParameter(cmd, "@equipmentId", dto.EquipmentId);
                AddParameter(cmd, "@dropzoneId", dto.DropzoneId);
                AddParameter(cmd, "@jumpNumber", dto.JumpNumber);
                AddParameter(cmd, "@jumpDate", dto.JumpDate);
                AddParameter(cmd, "@jumpType", dto.JumpType);
                AddParameter(cmd, "@exitAltitude", dto.ExitAltitude);
                AddParameter(cmd, "@landingPattern", dto.LandingPattern);
                AddParameter(cmd, "@notes", dto.Notes);
                AddParameter(cmd, "@totalJumpers", dto.TotalJumpers);
                cmd.ExecuteNonQuery(); */
            }
        }

        public void DeleteJump(int jumpId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Jump WHERE jump_id = @jumpId";
                AddParameter(cmd, "@jumpId", jumpId);
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
                AddParameter(cmd, "@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private JumpListDTO JumpReader(IDataReader reader)
        {
            return new JumpListDTO(DataMapper.MapDataToList<Jump>(reader));
            
             /* jump.JumpId = Convert.ToInt32(reader["jump_id"]);
                jump.UserId = Convert.ToInt32(reader["user_id"]);
                jump.WeatherId = Convert.ToInt32(reader["weather_id"]);
                jump.AircraftId = Convert.ToInt32(reader["aircraft_id"]);
                jump.EquipmentId = Convert.ToInt32(reader["equipment_id"]);
                jump.DropzoneId = Convert.ToInt32(reader["dropzone_id"]);
                jump.JumpNumber = Convert.ToInt32(reader["jump_number"]);
                jump.JumpDate = Convert.ToDateTime(reader["jump_date"]);
                jump.JumpType = Convert.ToString(reader["jump_type"]);
                jump.ExitAltitude = Convert.ToInt32(reader["exit_altitude"]);
                jump.LandingPattern = Convert.ToString(reader["landing_pattern"]);
                jump.Notes = Convert.ToString(reader["notes"]);
                jump.TotalJumpers = Convert.ToInt32(reader["total_jumpers"]);
                jumps.Jumps.Add(jump); */
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
