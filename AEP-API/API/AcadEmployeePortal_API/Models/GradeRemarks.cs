using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class GradeRemarks
    {
        public int GradeRemarksID { get; set; }
        public string GradeRemarksDescription { get; set; }
        public string GradeRemarksCode { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<StudentGrades> StudentGrades { get; set; }
    }
}
