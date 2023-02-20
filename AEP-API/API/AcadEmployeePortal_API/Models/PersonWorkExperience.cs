using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonWorkExperience
    {
        public int PersonWorkExperienceId { get; set; }
        public int? PersonId { get; set; }
        public DateTime? InclusiveDateFrom { get; set; }
        public DateTime? InclusiveDateTo { get; set; }
        public string PositionTitle { get; set; }
        public string AgencyOfficeCompany { get; set; }
        public double? MonthlySalary { get; set; }
        public string SalaryGrade { get; set; }
        public int? AppointmentStatusId { get; set; }
        public bool? IsGovernmentService { get; set; }
        public bool? IsActive { get; set; }

        public virtual AppointmentStatus AppointmentStatus { get; set; }
        public virtual Person Person { get; set; }
    }
}
