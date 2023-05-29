using Logbook.PresentationLayer.DTO;

namespace Logbook.Models
{
    public class Dropzone
    {
        public int DropzoneId { get; set; }
        public string DropzoneName { get; set; }
        public string DropzoneCountry { get; set; }
        public string DropzonePhoneNumber { get; set; }
        public string DropzoneEmailAddress { get; set; }
        public string DropzoneState { get; set; }
        public string DropzoneCity { get; set; }
        public string DropzoneAddress { get; set; }

        public Dropzone()
        {

        }

        public Dropzone(DropzoneDTO dto)
        {
            DropzoneId = dto.DropzoneId;
            DropzoneName = dto.DropzoneName;
            DropzoneCountry = dto.DropzoneCountry;
            DropzonePhoneNumber = dto.DropzonePhoneNumber;
            DropzoneEmailAddress = dto.DropzoneEmailAddress;
            DropzoneState = dto.DropzoneState;
            DropzoneCity = dto.DropzoneCity;
            DropzoneAddress = dto.DropzoneAddress;
        }

    }
}
