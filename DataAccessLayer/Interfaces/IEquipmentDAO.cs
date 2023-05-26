using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IEquipmentDAO
    {
        public void AddEquipment(Equipment equipment);
        public Equipment GetEquipment(int equipmentId);
        public EquipmentList GetEquipmentList(int userId);
        public void UpdateEquipment(Equipment equipment);
        public void DeleteEquipment(int equipmentId);
    }
}
