using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class AddressTypeDto
    {
        public int AddressTypeID { get; set; }
        public string AddressTypeName { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
    }
}
