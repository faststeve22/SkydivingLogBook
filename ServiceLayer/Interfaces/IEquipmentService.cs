using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IEquipmentService
    {
         EquipmentDTO AddEquipment(EquipmentDTO dto);
         EquipmentDTO GetEquipmentById(int equipmentId);
         EquipmentListDTO GetEquipmentList();
         EquipmentListDTO GetEquipmentListByUserId();
         void UpdateEquipment(EquipmentDTO dto);
         void DeleteEquipment(int equipmentId);
    }
}
