using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class EquipmentDTO
    {
        public int EquipmentId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentBrand { get; set; }
        public string EquipmentModel { get; set; }

        public EquipmentDTO()
        {

        }
        public EquipmentDTO(Equipment equipment)
        {
            EquipmentId = equipment.EquipmentId;
            EquipmentType = equipment.EquipmentType;
            EquipmentBrand = equipment.EquipmentBrand;
            EquipmentModel = equipment.EquipmentModel;
        }
    }
}
