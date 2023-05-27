using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IEquipmentService
    {
        public void AddEquipment(EquipmentDTO dto);
        public Equipment GetEquipmentById(int equipmentId);
        public EquipmentList GetEquipmentList();
        public EquipmentList GetEquipmentListByUserId(int userId);
        public void UpdateEquipment(EquipmentDTO dto);
        public void DeleteEquipment(int equipmentId);

    }
}
