using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
