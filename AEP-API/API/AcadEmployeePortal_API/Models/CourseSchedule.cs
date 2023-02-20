using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class CourseSchedule
    {
        public int CourseScheduleId { get; set; }
        public string Edpcode { get; set; }
        public int? CourseId { get; set; }
        public int? DayId { get; set; }
        public TimeSpan? TimeStart { get; set; }     
        public TimeSpan? TimeEnd { get; set; }
        
        public int? RoomId { get; set; }
        public int? TermId { get; set; }
        public int? SemesterId { get; set; }
        public bool? IsActive { get; set; }
        
        public int? MidDayIDTimeStart { get; set; }
      
        public int? MidDayIDTimeEnd { get; set; }
        public virtual MidDay MidDayTimeStart { get; set; }      
        public virtual MidDay MidDayTimeEnd { get; set; }       
        public virtual Course Course { get; set; }
        public virtual Day Day { get; set; }
        public virtual Room Room { get; set; }
        public virtual Semester Semester { get; set; }
       // public virtual Teacher Teacher { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<StudentCourseSchedule> StudentCourseSchedules { get; set; }
        public virtual ICollection<TeacherCourseSchedule> TeacherCourseSchedules { get; set; }
    }
}
