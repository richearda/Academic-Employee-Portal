using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class TeacherCourseSchedulesDto
    {
        public int TeacherId { get; set; }
        public int CourseScheduleId { get; set; }
        public TeacherDto Teacher { get; set; }
        public CourseSchedulesDto CourseSchedules { get; set; }
    }

}