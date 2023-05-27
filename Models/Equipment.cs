using Logbook.PresentationLayer.DTO;

namespace Logbook.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentBrand { get; set; }
        public string EquipmentModel { get; set; }

        public Equipment()
        {

        }
        public Equipment(EquipmentDTO dto)
        {
            EquipmentId = dto.EquipmentId;
            EquipmentType = dto.EquipmentType;
            EquipmentBrand = dto.EquipmentBrand;
            EquipmentModel = dto.EquipmentModel;
        }
    }
}
