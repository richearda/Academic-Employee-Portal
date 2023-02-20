using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentNo { get; set; }
        public string LRNNo { get; set; }
        public int? PersonId { get; set; }
        public int? ProgramId { get; set; }
        public int? MajorId { get; set; }
        public string YearLevel { get; set; }
        public bool IsActive { get; set; }


        public virtual Major Major { get; set; }
        public virtual Person Person { get; set; }
        public virtual Programs Program { get; set; }
        public virtual ICollection<StudentCourseSchedule> StudentSchedules { get; set; }
    }
}
