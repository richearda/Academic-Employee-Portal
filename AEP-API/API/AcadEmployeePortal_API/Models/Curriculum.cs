using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Curriculum
    {
        public int CurriculumId { get; set; }
        public string CurriculumName { get; set; }
        public int? ProgramId { get; set; }
        public int? MajorId { get; set; }
        public DateTime? Effectivity { get; set; }
        public string Cmo { get; set; }
        public int? TermId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Major Major { get; set; }
        public virtual Programs Program { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<CurriculumCourse> CurriculumCourses { get; set; }
    }
}
