using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Citizenship { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }     
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string PictureLink { get; set; }
        public EmployeeDto Employee { get; set; }
        public AddressDto Address { get; set; }
    }
}
