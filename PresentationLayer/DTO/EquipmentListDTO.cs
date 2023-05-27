using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class EquipmentListDTO
    {
        public List<Equipment> _equipmentList { get; set; }

        public EquipmentListDTO(List<Equipment> equipmentList)
        {
            _equipmentList = equipmentList;
        }

        public EquipmentListDTO(EquipmentList equipmentList)
        {
            _equipmentList = equipmentList.Equipment;
        }
    }
}
