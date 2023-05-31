using Logbook.DataAccessLayer.Interfaces;
using Logbook.ExceptionHandler.Exceptions;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Logbook.DataAccessLayer.DAO
{
    public class EquipmentDAO : IEquipmentDAO
    {
        IDbConnectionFactory _connectionFactory;
        IDaoUtilities _daoUtilities;
        public EquipmentDAO(IDbConnectionFactory connectionFactory, IDaoUtilities daoUtilities)
        {
            _connectionFactory = connectionFactory;
            _daoUtilities = daoUtilities;
        }

        public EquipmentDTO AddEquipment(EquipmentDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Equipment (equipment_brand, equipment_model, equipment_type) VALUES (@equipmentBrand, @equipmentModel, @equipmentType)";
                    _daoUtilities.AddParameter(cmd, dto);
                    IDataReader reader = cmd.ExecuteReader();
                   return new EquipmentDTO(_daoUtilities.MapDataToList<Equipment>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("AddEquipment", ex);
            }

        }

        public EquipmentDTO GetEquipmentById(int equipmentId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment WHERE equipment_id = @equipmentId";
                    _daoUtilities.AddParameter(cmd, equipmentId, "@equipmentId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new EquipmentDTO(_daoUtilities.MapDataToList<Equipment>(reader)[0]);
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("GetEquipmentById", ex);
            }

        }

        public EquipmentListDTO GetEquipmentList()
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment";
                    IDataReader reader = cmd.ExecuteReader();
                    return new EquipmentListDTO(_daoUtilities.MapDataToList<Equipment>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("GetEquipmentList", ex);
            }

        }

        public EquipmentListDTO GetEquipmentListByUserId(int userId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT Equipment.equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment JOIN Jump on Equipment.equipment_id = Jump.equipment_id WHERE user_id = @userId";
                    _daoUtilities.AddParameter(cmd, userId, "@userId");
                    IDataReader reader = cmd.ExecuteReader();
                    return new EquipmentListDTO(_daoUtilities.MapDataToList<Equipment>(reader));
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("GetEquipmentlistByUserId", ex);
            }

        }

        public void UpdateEquipment(EquipmentDTO dto)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Equipment SET equipment_brand = @equipmentBrand, equipment_model = @equipmentModel, equipment_type = @equipmentType WHERE equipment_id = @equipmentId";
                    _daoUtilities.AddParameter(cmd, dto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("UpdateEquipment", ex);
            }
        }

        public void DeleteEquipment(int equipmentId)
        {
            try
            {
                using (IDbConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Equipment WHERE equipment_id = @equipmentId";
                    _daoUtilities.AddParameter(cmd, equipmentId, "@equipmentId");
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new EquipmentException("DeleteEquipment", ex);
            }

        }
    }
}
