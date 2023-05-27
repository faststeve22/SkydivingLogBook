using Logbook.PresentationLayer.DTO;

namespace Logbook.Models.Lists
{
    public class EquipmentList
    {
        public List<Equipment> Equipment { get; set; }
        public EquipmentList(List<Equipment> equipment)
        {
            Equipment = equipment;
        }

        public EquipmentList(EquipmentListDTO dto)
        {
            Equipment = dto._equipmentList;
        }
    }
}
