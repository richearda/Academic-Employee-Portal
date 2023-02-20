using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Person> People { get; set; }

    }
}
