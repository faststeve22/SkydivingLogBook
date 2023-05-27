using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentDAO _equipmentDAO;

        public EquipmentService(IEquipmentDAO equipmentDAO)
        {
            _equipmentDAO = equipmentDAO;
        }

        public void AddEquipment(EquipmentDTO dto)
        {
            Equipment equipment = new Equipment(dto);
            _equipmentDAO.AddEquipment(equipment);
        }

        public EquipmentDTO GetEquipmentById(int equipmentId)
        {
            return new EquipmentDTO(_equipmentDAO.GetEquipmentById(equipmentId));
        }

        public EquipmentListDTO GetEquipmentList()
        {
            return new EquipmentListDTO(_equipmentDAO.GetEquipmentList());
        }

        public EquipmentListDTO GetEquipmentListByUserId(int userId)
        {
            return new EquipmentListDTO(_equipmentDAO.GetEquipmentListByUserId(userId));
        }

        public void UpdateEquipment(EquipmentDTO dto)
        {
            Equipment equipment = new Equipment(dto);
            _equipmentDAO.UpdateEquipment(equipment);
        }

        public void DeleteEquipment(int equipmentId)
        {
            _equipmentDAO.DeleteEquipment(equipmentId);
        }
        
    }
}
