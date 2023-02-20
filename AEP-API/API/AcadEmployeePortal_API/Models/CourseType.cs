using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class CourseType
    {
        public int CourseTypeID { get; set; }
        public string CourseTypeName { get; set; }
        public string CourseTypeDescription { get; set; }
        public bool IsActive { get; set; }

        //Navigation Property
        //public virtual ICollection<Course> Courses { get; set; }
    }
}
