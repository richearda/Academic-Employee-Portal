using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public int MidDayTimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public int MidDayTimeEnd { get; set; }
        //Nav and FK Prop
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
