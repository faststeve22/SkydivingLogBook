using Logbook.DataAccessLayer.Interfaces;
using Logbook.PresentationLayer.DTO;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class DbUserDAO : IDbUserDAO
    {
        IDbConnectionFactory _connectionFactory;

        public DbUserDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddUser(UserDTO user)
        {
            using(IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DbUser (username, first_name, last_name, email_address) Values (@username, @first_name, @last_name, @email_Address)";
                AddParameter(cmd, "@username", user.Username);
                AddParameter(cmd, "@first_name", user.FirstName);
                AddParameter(cmd, "@last_name", user.LastName);
                AddParameter(cmd, "@email_Address", user.EmailAddress);
                cmd.ExecuteNonQuery();
            }
        }

        public UserDTO GetUser(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT user_id, username, first_name, last_name, email-address FROM DbUser WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return UserReader(reader);
                }
                else
                {
                    throw new Exception("User ID Not Found");
                }
            }
        }

        public void UpdateUser(UserDTO user)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE DbUser SET username = @username, first_name = @firstName, last_name = @lastName, email_address = @emailAddress WHERE user_id = @userId";
                AddParameter(cmd, "@username", user.Username);
                AddParameter(cmd, "@firstName", user.FirstName);
                AddParameter(cmd, "@lastName", user.LastName);
                AddParameter(cmd, "@emailAddress", user.EmailAddress);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM DbUser WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private UserDTO UserReader(IDataReader reader)
        {
            UserDTO dto = new UserDTO();
            dto.UserId = Convert.ToInt32(reader["user_id"]);
            dto.Username = Convert.ToString(reader["username"]);
            dto.FirstName = Convert.ToString(reader["first_name"]);
            dto.LastName = Convert.ToString(reader["last_name"]);
            dto.EmailAddress = Convert.ToString(reader["email_address"]);
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
