using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Semester
    {

        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string SemesterCode { get; set; }
        public bool? IsCurrent { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<CurriculumCourse> CurriculumCourses { get; set; }
        //public virtual ICollection<EvaluationResponse> EvaluationResponses { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
