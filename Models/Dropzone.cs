using Logbook.PresentationLayer.DTO;

namespace Logbook.Models
{
    public class Dropzone
    {
        public int Dropzone_id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Dropzone()
        {

        }

        public Dropzone(DropzoneDTO dto)
        {
            Dropzone_id = dto.Dropzone_id;
            Name = dto.Name;
            Country = dto.Country;
            PhoneNumber = dto.PhoneNumber;
            EmailAddress = dto.EmailAddress;
            State = dto.State;
            City = dto.City;
            Address = dto.Address;
        }

    }
}
