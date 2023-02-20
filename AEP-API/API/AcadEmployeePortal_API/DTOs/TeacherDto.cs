using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public PersonDto Person { get; set; }
        public CollegeDto College { get; set; }
        
        public ICollection<TeacherCourseSchedulesDto> CourseSchedules { get; set; }
    }
}
