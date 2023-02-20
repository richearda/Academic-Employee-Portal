using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class StudentCourseSchedule
    {
        public int StudentCourseScheduleId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseScheduleId { get; set; }
        public bool? IsActive { get; set; }
        public virtual CourseSchedule CourseSchedules { get; set; }
        public virtual Student Student { get; set; }
        
    }
}
