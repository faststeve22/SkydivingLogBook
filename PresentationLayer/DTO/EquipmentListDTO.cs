using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class EquipmentListDTO
    {
        public List<Equipment> _equipmentList { get; set; }

        public EquipmentListDTO()
        {
             _equipmentList = new List<Equipment>();
        }
        public EquipmentListDTO(List<Equipment> equipmentList)
        {
            _equipmentList = new List<Equipment>();
            _equipmentList = equipmentList;
        }

        public EquipmentListDTO(EquipmentList equipmentList)
        {
            _equipmentList = new List<Equipment>();
            _equipmentList = equipmentList.Equipment;
        }
    }
}
