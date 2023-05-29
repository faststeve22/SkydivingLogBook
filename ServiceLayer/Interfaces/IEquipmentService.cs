using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IEquipmentService
    {
        public void AddEquipment(EquipmentDTO dto);
        public EquipmentDTO GetEquipmentById(int equipmentId);
        public EquipmentListDTO GetEquipmentList();
        public EquipmentListDTO GetEquipmentListByUserId();
        public void UpdateEquipment(EquipmentDTO dto);
        public void DeleteEquipment(int equipmentId);
    }
}
