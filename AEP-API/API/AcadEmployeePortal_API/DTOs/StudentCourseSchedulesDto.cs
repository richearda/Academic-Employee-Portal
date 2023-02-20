using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class StudentCourseSchedulesDto
    {
        public int StudentId { get; set; }
        public int CourseScheduleId { get; set; }
        public StudentDto Student { get; set; }
        public CourseSchedulesDto CourseSchedules { get; set; }
    }
}
