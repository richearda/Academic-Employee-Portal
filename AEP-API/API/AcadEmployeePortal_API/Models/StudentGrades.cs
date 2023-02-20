using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class StudentGrades
    {
        public int StudentGradesID { get; set; }
        public int? StudentScheduleId { get; set; }
        public decimal? PrelimPeriodGrade { get; set; }
        public decimal? MidtermPeriodGrade { get; set; }
        public decimal? SemiFinalPeriodGrade { get; set; }
        public decimal? FinalPeriodGrade { get; set; }
        public decimal? FinalGeneralAverage { get; set; }
        public int? GradeRemarksId { get; set; }

        //public virtual GradeRemarks GradeRemarks { get; set; }
        //public virtual StudentSchedule StudentSchedule { get; set; }
    }
}
