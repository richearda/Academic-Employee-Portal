using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class MidDay
    {
        [Key]
        public int MidDayId { get; set; }
        public string MidDayName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<CourseSchedule> CourseScheduleMidDayIdTimeEnd { get; set; }
        public virtual ICollection<CourseSchedule> CourseScheduleMidDayIdTimeStart { get; set; }
    }
}
