using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonEducationalBackground
    {
        public int PersonEducationalBackgroundId { get; set; }
        public int? PersonId { get; set; }
        public int? EducationLevelId { get; set; }
        public string SchoolName { get; set; }
        public string BasicEducationorDegree { get; set; }
        public DateTime? AttendancePeriodFrom { get; set; }
        public DateTime? AttendancePeriodTo { get; set; }
        public int? HighestLevelOrUnitsEarned { get; set; }
        public int? YearGraduated { get; set; }
        public string ScholarshipOrAcademicHonors { get; set; }
        public bool? IsActive { get; set; }

        public virtual EducationLevel EducationLevel { get; set; }
        public virtual Person Person { get; set; }
    }
}
