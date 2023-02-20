using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public bool? IsActive { get; set; }
        //public int CourseID { get; set; }
        public ICollection<Course> Courses { get; set; }
        public virtual ICollection<CollegeDepartment> CollegeDepartments { get; set; }
    }
}
