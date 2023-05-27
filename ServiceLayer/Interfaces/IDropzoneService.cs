using Logbook.Models;
using Logbook.Models.Lists;
using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IDropzoneService
    {
        public Dropzone GetDropzoneById(int dropzoneId);
        public DropzoneList GetDropzoneList();
        public DropzoneList GetDropzoneListByUserId(int userId);
        public void AddDropzone(DropzoneDTO dto);
        public void DeleteDropzone(int dropzoneId);
    }
}
