using Logbook.PresentationLayer.DTO;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDropzoneDAO
    {
        DropzoneDTO AddDropzone(DropzoneDTO dto);
        DropzoneDTO GetDropzone(int dropzoneId);
        DropzoneListDTO GetDropzoneListByUserId(int userId);
        DropzoneListDTO GetDropzoneList();

        void UpdateDropzone(DropzoneDTO dto);
        void DeleteDropzone(int dropzoneId);
    }
}
