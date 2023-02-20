using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonChild
    {
        public int PersonChildId { get; set; }
        public int? PersonId { get; set; }
        public string ChildName { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Person Person { get; set; }
    }
}
