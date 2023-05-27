using Logbook.Models;

namespace Logbook.PresentationLayer.DTO
{
    public class DropzoneDTO
    {
        public int Dropzone_id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public DropzoneDTO()
        {

        }

        public DropzoneDTO(Dropzone dropzone)
        {
            Dropzone_id = dropzone.Dropzone_id;
            Name = dropzone.Name;
            Country = dropzone.Country;
            PhoneNumber = dropzone.PhoneNumber;
            EmailAddress = dropzone.EmailAddress;
            State = dropzone.State;
            City = dropzone.City;
            Address = dropzone.Address;
        }

    }
}
