using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using System.Data;

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

        public void AddEquipment(EquipmentDTO dto)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Equipment (equipment_brand, equipment_model, equipment_type) VALUES (@equipmentBrand, @equipmentModel, @equipmentType)";
                _daoUtilities.AddParameter(cmd, dto);
                cmd.ExecuteNonQuery();
            }
        }

        public EquipmentDTO GetEquipmentById(int equipmentId)
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

        public EquipmentListDTO GetEquipmentList()
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

        public EquipmentListDTO GetEquipmentListByUserId(int userId)
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

        public void UpdateEquipment(EquipmentDTO dto)
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

        public void DeleteEquipment(int equipmentId)
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
    }
}
