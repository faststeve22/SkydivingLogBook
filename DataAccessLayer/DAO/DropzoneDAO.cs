using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
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

        public void AddDropzone(Dropzone dropzone)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Dropzone (dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address) VALUES(@dropzoneName, @dropzoneCountry, @dropzonePhoneNumber, @dropzoneEmailAddress, @dropzoneState, @dropzoneCity, @dropzoneAddress)";
                AddParameter(cmd, "@dropzoneName", dropzone.Name);
                AddParameter(cmd, "@dropzoneCountry", dropzone.Country);
                AddParameter(cmd, "@dropzonePhoneNumber", dropzone.PhoneNumber);
                AddParameter(cmd, "@dropzoneEmailAddress", dropzone.EmailAddress);
                AddParameter(cmd, "@dropzoneState", dropzone.State);
                AddParameter(cmd, "@dropzoneCity", dropzone.City);
                AddParameter(cmd, "@dropzoneAddress", dropzone.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public Dropzone GetDropzone(int dropzoneId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone WHERE dropzone_id = @dropzoneId";
                AddParameter(cmd, "@dropzoneId", dropzoneId);
                IDataReader reader = cmd.ExecuteReader();
                return DropzoneReader(reader)[0];
            }
        }

        public DropzoneList GetDropzoneList(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone JOIN Jump ON Jump.dropzone_id = Dropzone.dropzone_id WHERE Jump.user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return new DropzoneList(DropzoneReader(reader));
            }
        }

        public void UpdateDropzone(Dropzone dropzone)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Dropzone SET dropzone_name = @dropzone_name, dropzone_country = @dropzoneCountry, dropzone_phone_number = @dropzonePhoneNumber, dropzone_email_address = @dropzoneEmailAddress, dropzone_state = @dropzoneState, dropzone_city = @dropzoneCity, dropzone_address = @dropzoneAddress WHERE dropzone_id = @dropzoneId";
                AddParameter(cmd, "@dropzoneId", dropzone.Dropzone_id);
                AddParameter(cmd, "@dropzoneName", dropzone.Name);
                AddParameter(cmd, "@dropzoneCountry", dropzone.Country);
                AddParameter(cmd, "@dropzonePhoneNumber", dropzone.PhoneNumber);
                AddParameter(cmd, "@dropzoneState", dropzone.State);
                AddParameter(cmd, "@dropzoneCity", dropzone.City);
                AddParameter(cmd, "@dropzoneAddress", dropzone.Address);
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

        public List<Dropzone> DropzoneReader(IDataReader reader)
        {
            List<Dropzone> dropzones = new List<Dropzone>();
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
                dropzones.Add(dropzone);
            }
            return dropzones;
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
