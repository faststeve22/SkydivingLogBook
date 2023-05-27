using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
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

        public DropzoneDTO GetDropzoneById(int dropzoneId)
        {
            return new DropzoneDTO(_dropzoneDAO.GetDropzone(dropzoneId));
        }

        public DropzoneListDTO GetDropzoneList()
        {
            return new DropzoneListDTO(_dropzoneDAO.GetDropzoneList());
        }

        public DropzoneListDTO GetDropzoneListByUserId(int userId)
        {
            return new DropzoneListDTO(_dropzoneDAO.GetDropzoneListByUserId(userId));
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            Dropzone dropzone = new Dropzone(dto);
            _dropzoneDAO.AddDropzone(dropzone);
        }

        public void DeleteDropzone(int dropzoneId)
        {
            _dropzoneDAO.DeleteDropzone(dropzoneId);
        }
    }
}
