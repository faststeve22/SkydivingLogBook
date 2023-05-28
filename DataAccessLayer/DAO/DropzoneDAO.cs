using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class DropzoneDAO : IDropzoneDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public DropzoneDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Dropzone (dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address) VALUES(@dropzoneName, @dropzoneCountry, @dropzonePhoneNumber, @dropzoneEmailAddress, @dropzoneState, @dropzoneCity, @dropzoneAddress)";
                AddParameter(cmd, "@dropzoneName", dto.Name);
                AddParameter(cmd, "@dropzoneCountry", dto.Country);
                AddParameter(cmd, "@dropzonePhoneNumber", dto.PhoneNumber);
                AddParameter(cmd, "@dropzoneEmailAddress", dto.EmailAddress);
                AddParameter(cmd, "@dropzoneState", dto.State);
                AddParameter(cmd, "@dropzoneCity", dto.City);
                AddParameter(cmd, "@dropzoneAddress", dto.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public DropzoneDTO GetDropzone(int dropzoneId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone WHERE dropzone_id = @dropzoneId";
                AddParameter(cmd, "@dropzoneId", dropzoneId);
                IDataReader reader = cmd.ExecuteReader();
                return new DropzoneDTO(DropzoneReader(reader).Dropzones[0]);
            }
        }

        public DropzoneListDTO GetDropzoneList()
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone";
                IDataReader reader = cmd.ExecuteReader();
                return DropzoneReader(reader);
            }
        }

        public DropzoneListDTO GetDropzoneListByUserId(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Dropzone.dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone JOIN Jump ON Jump.dropzone_id = Dropzone.dropzone_id WHERE Jump.user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return DropzoneReader(reader);
            }
        }

        public void UpdateDropzone(DropzoneDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Dropzone SET dropzone_name = @dropzone_name, dropzone_country = @dropzoneCountry, dropzone_phone_number = @dropzonePhoneNumber, dropzone_email_address = @dropzoneEmailAddress, dropzone_state = @dropzoneState, dropzone_city = @dropzoneCity, dropzone_address = @dropzoneAddress WHERE dropzone_id = @dropzoneId";
                AddParameter(cmd, "@dropzoneId", dto.Dropzone_id);
                AddParameter(cmd, "@dropzoneName", dto.Name);
                AddParameter(cmd, "@dropzoneCountry", dto.Country);
                AddParameter(cmd, "@dropzonePhoneNumber", dto.PhoneNumber);
                AddParameter(cmd, "@dropzoneState", dto.State);
                AddParameter(cmd, "@dropzoneCity", dto.City);
                AddParameter(cmd, "@dropzoneAddress", dto.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDropzone(int dropzoneId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Dropzone WHERE dropzone_id = @dropzoneId";
                AddParameter(cmd, "@dropzoneId", dropzoneId);
                cmd.ExecuteNonQuery();
            }
        }

        public DropzoneListDTO DropzoneReader(IDataReader reader)
        {
            DropzoneListDTO dto = new DropzoneListDTO();
            while (reader.Read())
            {
                Dropzone dropzone = new Dropzone();
                dropzone.Dropzone_id = Convert.ToInt32(reader["dropzone_id"]);
                dropzone.Name = Convert.ToString(reader["dropzone_name"]);
                dropzone.Country = Convert.ToString(reader["dropzone_country"]);
                dropzone.PhoneNumber = Convert.ToString(reader["dropzone_phone_number"]);
                dropzone.EmailAddress = Convert.ToString(reader["dropzone_email_address"]);
                dropzone.State = Convert.ToString(reader["dropzone_state"]);
                dropzone.City = Convert.ToString(reader["dropzone_city"]);
                dropzone.Address = Convert.ToString(reader["dropzone_address"]);
                dto.Dropzones.Add(dropzone);
            }
            return dto;
        }

        public void AddParameter(IDbCommand cmd, string paramName, object value)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = paramName;
            Parameter.Value = value;
            cmd.Parameters.Add(Parameter);
        }
    }
}
