using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using System.Data;
using System.Security.Cryptography;

namespace Logbook.DataAccessLayer.DAO
{
    public class DbUserDAO : IDbUserDAO
    {
        IDbConnectionFactory _connectionFactory;

        public DbUserDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User AddUser(User user)
        {
            using(IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "";
                AddParameter(cmd, "user_id", user.UserId);
                AddParameter(cmd, "username", user.Username);
                AddParameter(cmd, "email_address", user.EmailAddress);
                IDataReader reader = cmd.ExecuteReader();
                User CreatedUser = UserReader(reader);
                return CreatedUser;
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
