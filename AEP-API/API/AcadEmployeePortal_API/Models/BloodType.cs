using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class BloodType
    {

        public int BloodTypeId { get; set; }
        public string BloodTypeClassification { get; set; }
        public bool? IsActive { get; set; }
        //public virtual ICollection<Person> People { get; set; }

    }
}
