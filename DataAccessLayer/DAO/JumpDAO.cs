using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
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
        public void AddJump(Jump jump)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers INTO Jump";
                AddParameter(cmd, "@userId", jump.UserId);
                AddParameter(cmd, "@weatherId", jump.WeatherId);
                AddParameter(cmd, "@aircraftId", jump.AircraftId);
                AddParameter(cmd, "@equipmentId", jump.EquipmentId);
                AddParameter(cmd, "@dropzoneId", jump.DropzoneId);
                AddParameter(cmd, "@jumpNumber", jump.JumpNumber);
                AddParameter(cmd, "@jumpDate", jump.JumpDate);
                AddParameter(cmd, "@jumpType", jump.JumpType);
                AddParameter(cmd, "@exitAltitude", jump.ExitAltitude);
                AddParameter(cmd, "@landingPattern", jump.LandingPattern);
                AddParameter(cmd, "@notes", jump.Notes);
                AddParameter(cmd, "@totalJumpers", jump.TotalJumpers);
                cmd.ExecuteNonQuery();
            }
        }

        public Jump GetJump(int jumpId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT jump_id, user_id, weather_id, aircraft_id, equipment_id, dropzone_id, jump_number, jump_date, jump_type, exit_altitude, landing_pattern, notes, total_jumpers FROM Jump WHERE jump_id = @jumpId";
                AddParameter(cmd, "@jumpId", jumpId);
                IDataReader reader = cmd.ExecuteReader();
                return JumpReader(reader);
            }
        }

        public void UpdateJump(Jump jump)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Jump SET user_id = @userId, weather_id = @weatherId, aircraft_id = @aircraftId, equipment_id = @equipmentId, dropzone_id = @dropzoneId, jump_number = @jumpNumber, jump_date = @jumpDate, jump_type = @jumpType, exit_altitude = @exitAltitude, landing_pattern = @landingPattern, notes = @notes, total_jumpers = @totalJumpers WHERE jump_id = @jumpId";
                AddParameter(cmd, "@jumpId", jump.JumpId);
                AddParameter(cmd, "@userId", jump.UserId);
                AddParameter(cmd, "@weatherId", jump.WeatherId);
                AddParameter(cmd, "@aircraftId", jump.AircraftId);
                AddParameter(cmd, "@equipmentId", jump.EquipmentId);
                AddParameter(cmd, "@dropzoneId", jump.DropzoneId);
                AddParameter(cmd, "@jumpNumber", jump.JumpNumber);
                AddParameter(cmd, "@jumpDate", jump.JumpDate);
                AddParameter(cmd, "@jumpType", jump.JumpType);
                AddParameter(cmd, "@exitAltitude", jump.ExitAltitude);
                AddParameter(cmd, "@landingPattern", jump.LandingPattern);
                AddParameter(cmd, "@notes", jump.Notes);
                AddParameter(cmd, "@totalJumpers", jump.TotalJumpers);
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
                AddParameter(cmd, "@jumpId", jumpId);
                cmd.ExecuteNonQuery();
            }
        }

        private Jump JumpReader(IDataReader reader)
        {
            Jump jump = new Jump();
            jump.JumpId = Convert.ToInt32(reader["jump_id"]);
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
            return jump;
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
