using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Citizenship
    {
        public int CitizenshipId { get; set; }
        public string CitizenshipStatus { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}
