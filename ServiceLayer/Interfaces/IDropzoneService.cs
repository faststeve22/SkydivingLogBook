using Logbook.PresentationLayer.DTO;

namespace Logbook.ServiceLayer.Interfaces
{
    public interface IDropzoneService
    {
         DropzoneDTO GetDropzoneById(int dropzoneId);
         DropzoneListDTO GetDropzoneList();
         DropzoneListDTO GetDropzoneListByUserId();
         DropzoneDTO AddDropzone(DropzoneDTO dto);
         void UpdateDropzone(DropzoneDTO dto);
         void DeleteDropzone(int dropzoneId);

    }
}
