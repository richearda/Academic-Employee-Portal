using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class DualCitizenshipAcquisition
    {
        public int DualCitizenshipAcquisitionId { get; set; }
        public string DualCitizenshipAcquisitionType { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
