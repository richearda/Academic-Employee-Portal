using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class TeacherCourseSchedule
    {
        public int TeacherCourseScheduleId { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseScheduleId { get; set; }
        public bool? IsActive { get; set; }
        public virtual CourseSchedule CourseSchedule { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
