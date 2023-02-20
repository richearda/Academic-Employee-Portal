using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class CourseSchedulesDto
    {
        public int CourseScheduleId { get; set; }      
        public string EdpCode { get; set; }
        public CourseDto Course { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Day { get; set; }
        public string MidDayTimeStart { get; set; }
        public string MidDayTimeEnd { get; set; }    
        public ICollection<StudentCourseSchedulesDto> StudentSchedules { get; set; }
        public ICollection<TeacherCourseSchedulesDto> TeacherSchedules { get; set; }
        




    }
}
