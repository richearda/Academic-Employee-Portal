using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class DesignationStatus
    {
        public int DesignationStatusID { get; set; }
        public string DesignationStatusDescription { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
