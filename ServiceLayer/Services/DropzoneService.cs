using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class DropzoneService : IDropzoneService
    {
        private readonly IDropzoneDAO _dropzoneDAO;

        public DropzoneService(IDropzoneDAO dropzoneDAO)
        {
            _dropzoneDAO = dropzoneDAO;
        }

        public Dropzone GetDropzoneById(int dropzoneId)
        {
            return _dropzoneDAO.GetDropzone(dropzoneId);
        }

        public DropzoneList GetDropzoneList()
        {
            return _dropzoneDAO.GetDropzoneList();
        }

        public DropzoneList GetDropzoneListByUserId(int userId)
        {
            return _dropzoneDAO.GetDropzoneListByUserId(userId);
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            _dropzoneDAO.AddDropzone(ConvertDTOToModel(dto));
        }

        public void DeleteDropzone(int dropzoneId)
        {
            _dropzoneDAO.DeleteDropzone(dropzoneId);
        }

        private Dropzone ConvertDTOToModel(DropzoneDTO dto)
        {
            Dropzone dropzone = new Dropzone();
            if (dto.Dropzone_id != 0)
            {
                dropzone.Dropzone_id = dto.Dropzone_id;
            }
            dropzone.Name = dto.Name;
            dropzone.PhoneNumber = dto.PhoneNumber;
            dropzone.EmailAddress = dto.EmailAddress;
            dropzone.State = dto.State;
            dropzone.City = dto.City;
            dropzone.Address = dto.Address;
            return dropzone;
        }
    }
}
