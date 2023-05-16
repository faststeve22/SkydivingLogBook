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

        private User UserReader(IDataReader reader)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(reader["user_id"]);
            user.Username = Convert.ToString(reader["username"]);
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
