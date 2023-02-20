using System;
using System.Collections.Generic;

namespace ISMS_API.Models
{
    public class College
    {
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string CollegeCode { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CollegeDepartment> CollegeDepartments { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public Dean Dean { get; set; }

    }
}