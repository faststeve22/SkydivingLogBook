using Logbook.PresentationLayer.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Logbook.Models.Lists
{
    public class DropzoneList
    {
        public List<Dropzone> Dropzones { get; set; }

        public DropzoneList(List<Dropzone> dropzones)
        {
            Dropzones = dropzones;
        }

        public DropzoneList(DropzoneListDTO dto)
        {
            Dropzones = dto.Dropzones;
        }
    }
}
