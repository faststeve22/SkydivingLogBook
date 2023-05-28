using Logbook.DataAccessLayer.Interfaces;
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
            return _dropzoneDAO.GetDropzone(dropzoneId);
        }

        public DropzoneListDTO GetDropzoneList()
        {
            return _dropzoneDAO.GetDropzoneList();
        }

        public DropzoneListDTO GetDropzoneListByUserId()
        {
            return _dropzoneDAO.GetDropzoneListByUserId(_userService.GetUserId());
        }

        public void AddDropzone(DropzoneDTO dto)
        {
            _dropzoneDAO.AddDropzone(dto);
        }

        public void UpdateDropzone(DropzoneDTO dto)
        {
            _dropzoneDAO.UpdateDropzone(dto);
        }

        public void DeleteDropzone(int dropzoneId)
        {
            _dropzoneDAO.DeleteDropzone(dropzoneId);
        }

    }
}
