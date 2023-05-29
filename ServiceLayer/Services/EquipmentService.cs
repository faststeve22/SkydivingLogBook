using Logbook.DataAccessLayer.Interfaces;
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
            _equipmentDAO.AddEquipment(dto);
        }

        public EquipmentDTO GetEquipmentById(int equipmentId)
        {
            return _equipmentDAO.GetEquipmentById(equipmentId);
        }

        public EquipmentListDTO GetEquipmentList()
        {
            return _equipmentDAO.GetEquipmentList();
        }

        public EquipmentListDTO GetEquipmentListByUserId()
        {
            
            return _equipmentDAO.GetEquipmentListByUserId(_userService.GetUserId());
        }

        public void UpdateEquipment(EquipmentDTO dto)
        {
            _equipmentDAO.UpdateEquipment(dto);
        }

        public void DeleteEquipment(int equipmentId)
        {
            _equipmentDAO.DeleteEquipment(equipmentId);
        }
        
    }
}
