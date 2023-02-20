using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public int Units { get; set; }
        public int NoOfHours { get; set; }
        public int CourseTypeID { get; set; }
        public bool IsActive { get; set; }

        //Navigation Properties
        public virtual CourseType CourseType { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<CurriculumCourse> CurriculumCourses { get; set; }
        public virtual CourseSchedule Schedule { get; set; }
    }
}
