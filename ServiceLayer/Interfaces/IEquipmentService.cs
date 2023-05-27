﻿using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IEquipmentService
    {
        public void AddEquipment(EquipmentDTO dto);
        public EquipmentDTO GetEquipmentById(int equipmentId);
        public EquipmentListDTO GetEquipmentList();
        public EquipmentListDTO GetEquipmentListByUserId(int userId);
        public void UpdateEquipment(EquipmentDTO dto);
        public void DeleteEquipment(int equipmentId);
        public void DeleteEquipmentByUserId(int userId);

    }
}
