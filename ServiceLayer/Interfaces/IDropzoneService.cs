using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IDropzoneService
    {
        public DropzoneDTO GetDropzoneById(int dropzoneId);
        public DropzoneListDTO GetDropzoneList();
        public DropzoneListDTO GetDropzoneListByUserId();
        public void AddDropzone(DropzoneDTO dto);
        public void UpdateDropzone(DropzoneDTO dto);

        public void DeleteDropzone(int dropzoneId);

    }
}
