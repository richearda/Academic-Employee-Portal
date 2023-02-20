using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Day
    {

        public int DayId { get; set; }
        public string DayName { get; set; }
        public string DayCode { get; set; }
        public bool? IsActive { get; set; }
        //public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }


    }
}
