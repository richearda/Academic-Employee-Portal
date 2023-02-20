using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
