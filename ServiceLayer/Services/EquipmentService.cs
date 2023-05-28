using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentDAO _equipmentDAO;
        private readonly IUserService _userService;

        public EquipmentService(IEquipmentDAO equipmentDAO, IUserService userService)
        {
            _equipmentDAO = equipmentDAO;
            _userService = userService;
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

        public EquipmentListDTO GetEquipmentListByUserId()
        {
            
            return new EquipmentListDTO(_equipmentDAO.GetEquipmentListByUserId(_userService.GetUserId()));
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

        public void DeleteEquipmentByUserId()
        {
            _equipmentDAO.DeleteEquipmentByUserId(_userService.GetUserId());
        }
        
    }
}
