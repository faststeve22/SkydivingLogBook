using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
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

        public void AddUser(User user)
        {
            using(IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DbUser (user_id, username, first_name, last_name, email_address) Values (@user_id, @username, @first_name, @last_name, @email_Address)";
                AddParameter(cmd, "@user_id", user.UserId);
                AddParameter(cmd, "@username", user.Username);
                AddParameter(cmd, "@first_name", user.FirstName);
                AddParameter(cmd, "@last_name", user.LastName);
                AddParameter(cmd, "@email_Address", user.EmailAddress);
                cmd.ExecuteNonQuery();
                //User CreatedUser = UserReader(reader);
                //return CreatedUser;
            }
        }

        public User GetUser(int userId)
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

        public void UpdateUser(int userId, User user)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE DbUser SET (username, first_name, last_name, email_address) Values(@username, @firstName, @lastName, @emailAddress) WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
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

        private User UserReader(IDataReader reader)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(reader["user_id"]);
            user.Username = Convert.ToString(reader["username"]);
            user.FirstName = Convert.ToString(reader["first_name"]);
            user.LastName = Convert.ToString(reader["last_name"]);
            user.EmailAddress = Convert.ToString(reader["email_address"]);
            return user;
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
