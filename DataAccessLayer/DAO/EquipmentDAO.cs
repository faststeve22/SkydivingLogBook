using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using System.Data;

namespace Logbook.DataAccessLayer.DAO
{
    public class EquipmentDAO : IEquipmentDAO
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public EquipmentDAO(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddEquipment(Equipment equipment)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Equipment (equipment_brand, equipment_model, equipment_type) VALUES (@equipmentBrand, @equipmentModel, @equipmentType)";
                AddParameter(cmd, "@equipmentBrand", equipment.EquipmentBrand);
                AddParameter(cmd, "@equipmentModel", equipment.EquipmentModel);
                AddParameter(cmd, "@equipmentType", equipment.EquipmentType);
                cmd.ExecuteNonQuery();
            }
        }

        public Equipment GetEquipmentById(int equipmentId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment WHERE equipment_id = @equipmentId";
                AddParameter(cmd, "@equipmentId", equipmentId);
                IDataReader reader = cmd.ExecuteReader();
                return EquipmentReader(reader)[0];
            }
        }

        public EquipmentList GetEquipmentList()
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment";
                IDataReader reader = cmd.ExecuteReader();
                return new EquipmentList(EquipmentReader(reader));
            }
        }

        public EquipmentList GetEquipmentListByUserId(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT equipment_id, equipment_brand, equipment_model, equipment_type FROM Equipment JOIN Jump on Equipment.equipment_id = Jump.equipment_id WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                IDataReader reader = cmd.ExecuteReader();
                return new EquipmentList(EquipmentReader(reader));
            }
        }

        public void UpdateEquipment(Equipment equipment)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Equipment SET equipment_brand = @equipmentBrand, equipment_model = @equipmentModel, equipment_type = @equipmentType WHERE equipment_id = @equipmentId";
                AddParameter(cmd, "@equipmentId", equipment.EquipmentId);
                AddParameter(cmd, "@equipmentBrand", equipment.EquipmentBrand);
                AddParameter(cmd, "@equipmentModel", equipment.EquipmentModel);
                AddParameter(cmd, "@equipmentType", equipment.EquipmentType);
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
                AddParameter(cmd, "@equipmentId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEquipmentByUserId(int userId)
        {
            using (IDbConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Equipment JOIN Jump on Equipment.equipment_id = Jump.equipment_id WHERE user_id = @userId";
                AddParameter(cmd, "@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private List<Equipment> EquipmentReader(IDataReader reader)
        {
            List<Equipment> EquipmentList = new List<Equipment>();
            while(reader.Read())
            {
                Equipment equipment = new Equipment();
                equipment.EquipmentId = Convert.ToInt32(reader["equipment_id"]);
                equipment.EquipmentBrand = Convert.ToString(reader["equipment_brand"]);
                equipment.EquipmentModel = Convert.ToString(reader["equipment_model"]);
                equipment.EquipmentType = Convert.ToString(reader["equipment_type"]);
                EquipmentList.Add(equipment);
            }
            return EquipmentList;
        }

        private void AddParameter(IDbCommand cmd, string paramName, object value)
        {
            var Parameter = cmd.CreateParameter();
            Parameter.ParameterName = paramName;
            Parameter.Value = value;
            cmd.Parameters.Add(Parameter);
        }
    }
}
