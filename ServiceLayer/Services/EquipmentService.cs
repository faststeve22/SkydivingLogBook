using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
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
            _equipmentDAO.AddEquipment(ConvertDTOToModel(dto));
        }

        public Equipment GetEquipmentById(int equipmentId)
        {
            return _equipmentDAO.GetEquipmentById(equipmentId);
        }

        public EquipmentList GetEquipmentList()
        {
            return _equipmentDAO.GetEquipmentList();
        }

        public EquipmentList GetEquipmentListByUserId(int userId)
        {
            return _equipmentDAO.GetEquipmentListByUserId(userId);
        }

        public void UpdateEquipment(EquipmentDTO dto)
        {
            _equipmentDAO.UpdateEquipment(ConvertDTOToModel(dto));
        }

        public void DeleteEquipment(int equipmentId)
        {
            _equipmentDAO.DeleteEquipment(equipmentId);
        }

        private Equipment ConvertDTOToModel(EquipmentDTO dto)
        {
            Equipment equipment = new Equipment();
            if(dto.EquipmentId != 0)
            {
                equipment.EquipmentId = dto.EquipmentId;
            }
            equipment.EquipmentBrand = dto.EquipmentBrand;
            equipment.EquipmentModel = dto.EquipmentModel;
            equipment.EquipmentType = dto.EquipmentType;
            return equipment;
        }
    }
}
