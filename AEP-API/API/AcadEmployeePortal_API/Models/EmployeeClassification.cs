using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
  
    public class EmployeeClassification
    {
        public int EmployeeClassificationID { get; set; }
        public string EmployeeClassificationDescription { get; set; }
        public bool IsActive { get; set; }

        //Navigation Property
       //public virtual ICollection<Employee> Employees { get; set; }
    }
}
