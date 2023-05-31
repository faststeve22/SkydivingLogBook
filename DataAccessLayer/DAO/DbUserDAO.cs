using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Logbook.DataAccessLayer.DAO
{
    public class DbUserDAO : IDbUserDAO
    {
        IDbConnectionFactory _connectionFactory;
        IDaoUtilities _daoUtilities;

        public DbUserDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }

        public UserDTO AddUser(UserDTO user)
        {
            //Add try catch that sends Created User or exception to AltitudeAccess API via Rabbit MQ
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO DbUser (username, first_name, last_name, email_address) Values (@username, @first_name, @last_name, @email_Address)";
                    _daoUtilities.AddParameter(cmd, user);
                    IDataReader reader = cmd.ExecuteReader();
                    return new UserDTO(_daoUtilities.MapDataToList<Jumper>(reader)[0]);
                }
        }

        public UserDTO GetUser(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT user_id, username, first_name, last_name, email-address FROM DbUser WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    IDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UserDTO(_daoUtilities.MapDataToList<Jumper>(reader)[0]);
                    }
                    else
                    {
                        throw new UserNotFoundException("User ID not found.");
                    }
                }
                catch(SqlException ex) 
                {
                    throw new UserException("GetUser", ex);
                }
            }
        }

        public void UpdateUser(UserDTO user)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE DbUser SET username = @username, first_name = @firstName, last_name = @lastName, email_address = @emailAddress WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, user);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new UserException("UpdateUser", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM DbUser WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new UserException("DeleteUser", ex);
            }
        }
    }
}
