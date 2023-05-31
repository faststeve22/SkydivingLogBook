using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Logbook.DataAccessLayer.DAO
{
    public class DropzoneDAO : IDropzoneDAO
    {
        IDbConnectionFactory _connectionFactory;
        IDaoUtilities _daoUtilities;
        public DropzoneDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Dropzone (dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address) VALUES(@dropzoneName, @dropzoneCountry, @dropzonePhoneNumber, @dropzoneEmailAddress, @dropzoneState, @dropzoneCity, @dropzoneAddress)";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("AddDropzone", ex);
            }
        }

        public DropzoneDTO GetDropzone(int dropzoneId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone WHERE dropzone_id = @dropzoneId";
                    _daoUtilities.AddParameter(cmd, dropzoneId, "@dropzoneId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new DropzoneDTO(_daoUtilities.MapDataToList<Dropzone>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("GetDropzone", ex);
            }
        }

        public DropzoneListDTO GetDropzoneList()
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone";
                    IDataReader reader = cmd.ExecuteReader();
                    return new DropzoneListDTO(_daoUtilities.MapDataToList<Dropzone>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("GetDropzoneList", ex);
            }
        }

        public DropzoneListDTO GetDropzoneListByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT Dropzone.dropzone_id, dropzone_name, dropzone_country, dropzone_phone_number, dropzone_email_address, dropzone_state, dropzone_city, dropzone_address FROM Dropzone JOIN Jump ON Jump.dropzone_id = Dropzone.dropzone_id WHERE Jump.user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new DropzoneListDTO(_daoUtilities.MapDataToList<Dropzone>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("GetDropzoneListByUserId", ex);
            }
        }

        public void UpdateDropzone(DropzoneDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Dropzone SET dropzone_name = @dropzoneName, dropzone_country = @dropzoneCountry, dropzone_phone_number = @dropzonePhoneNumber, dropzone_email_address = @dropzoneEmailAddress, dropzone_state = @dropzoneState, dropzone_city = @dropzoneCity, dropzone_address = @dropzoneAddress WHERE dropzone_id = @dropzoneId";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("UpdateDropzone", ex);
            }
        }

        public void DeleteDropzone(int dropzoneId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Dropzone WHERE dropzone_id = @dropzoneId";
                    _daoUtilities.AddParameter(cmd, dropzoneId, "dropzoneId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new DropzoneException("DeleteDropzone", ex);
            }
        }
    }
}
