using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.DataAccessLayer.Interfaces
{
    public interface IDropzoneDAO
    {
        public void AddDropzone(Dropzone dropzone);
        public Dropzone GetDropzone(int dropzoneId);
        public DropzoneList GetDropzoneList(int userId);
        public void UpdateDropzone(Dropzone dropzone);
        public void DeleteDropzone(int dropzoneId);
    }
}
