using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
       public int? PersonId { get; set; }
        public int? CollegeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual College College { get; set; }
        //public CourseSchedule CourseSchedule { get; set; }
        public virtual Person Person { get; set; }
        
        public virtual ICollection<TeacherCourseSchedule> TeacherCourseSchedules { get; set; }
    }
}   
