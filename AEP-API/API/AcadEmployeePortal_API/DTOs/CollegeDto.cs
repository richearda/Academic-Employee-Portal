using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class CollegeDto
    {
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string CollegeCode { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TeacherDto> Teachers { get; set; }
    }
}
