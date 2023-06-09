﻿using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IEquipmentDAO
    {
        EquipmentDTO AddEquipment(EquipmentDTO dto);
        EquipmentDTO GetEquipmentById(int equipmentId);
        EquipmentListDTO GetEquipmentList();
        EquipmentListDTO GetEquipmentListByUserId(int userId);
        void UpdateEquipment(EquipmentDTO dto);
        void DeleteEquipment(int equipmentId);
    }
}
