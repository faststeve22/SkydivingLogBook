using Logbook.Models;
using Logbook.Models.Lists;

namespace Logbook.PresentationLayer.DTO
{
    public class DropzoneListDTO
    {
        public List<Dropzone> Dropzones { get; set; }

        public DropzoneListDTO()
        {

        }

        public DropzoneListDTO(DropzoneList list)
        {
            Dropzones = list.Dropzones;
        }
    }
}
