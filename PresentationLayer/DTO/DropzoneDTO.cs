using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class DropzoneDTO
    {
        public int DropzoneId { get; set; }
        public string DropzoneName { get; set; }
        public string DropzoneCountry { get; set; }
        public string DropzonePhoneNumber { get; set; }
        public string DropzoneEmailAddress { get; set; }
        public string DropzoneState { get; set; }
        public string DropzoneCity { get; set; }
        public string DropzoneAddress { get; set; }
        

        public DropzoneDTO()
        {

        }

        public DropzoneDTO(Dropzone dropzone)
        {
            DropzoneId = dropzone.DropzoneId;
            DropzoneName = dropzone.DropzoneName;
            DropzoneCountry = dropzone.DropzoneCountry;
            DropzonePhoneNumber = dropzone.DropzonePhoneNumber;
            DropzoneEmailAddress = dropzone.DropzoneEmailAddress;
            DropzoneState = dropzone.DropzoneState;
            DropzoneCity = dropzone.DropzoneCity;
            DropzoneAddress = dropzone.DropzoneAddress;
        }

    }
}
