namespace Logbook.Models.Lists
{
    public class EquipmentList
    {
        public List<Equipment> Equipment { get; set; }
        public EquipmentList(List<Equipment> equipment)
        {
            Equipment = equipment;
        }
    }
}
