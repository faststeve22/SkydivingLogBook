using Logbook.DataAccessLayer.Interfaces;
using Logbook.Models;
using Logbook.PresentationLayer.DTO;
using Logbook.ServiceLayer.Interfaces;

namespace Logbook.ServiceLayer.Services
{
    public class DropzoneService : IDropzoneService
    {
        private readonly IDropzoneDAO _dropzoneDAO;
        private readonly IUserService _userService;

        public DropzoneService(IDropzoneDAO dropzoneDAO, IUserService userService)
        {
            _dropzoneDAO = dropzoneDAO;
            _userService = userService;
        }

        public DropzoneDTO GetDropzoneById(int dropzoneId)
        {
            return new DropzoneDTO(_dropzoneDAO.GetDropzone(dropzoneId));
        }

        public DropzoneListDTO GetDropzoneList()
        {
            return new DropzoneListDTO(_dropzoneDAO.GetDropzoneList());
        }

        public DropzoneListDTO GetDropzoneListByUserId()
        {
            return new DropzoneListDTO(_dropzoneDAO.GetDropzoneListByUserId(_userService.GetUserId()));
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            Dropzone dropzone = new Dropzone(dto);
            _dropzoneDAO.AddDropzone(dropzone);
        }

        public void UpdateDropzone(DropzoneDTO dto)
        {
            Dropzone dropzone = new Dropzone(dto);
            _dropzoneDAO.UpdateDropzone(dropzone);
        }

        public void DeleteDropzone(int dropzoneId)
        {
            _dropzoneDAO.DeleteDropzone(dropzoneId);
        }
    }
}
