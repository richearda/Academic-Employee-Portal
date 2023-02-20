using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class CurriculumCourse
    {
        public int CurriculumCourseId { get; set; }
        public int? CurriculumId { get; set; }
        public int? YearLevel { get; set; }
        public int? SemesterId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Curriculum Curriculum { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
