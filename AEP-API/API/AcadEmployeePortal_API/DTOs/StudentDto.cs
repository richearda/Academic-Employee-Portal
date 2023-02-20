using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public string StudentNo { get; set; }
        public string LRNNo { get; set; }
        public PersonDto Person { get; set; }
        public ProgramDto Program { get; set; }
        public string MajorName { get; set; }
        public string YearLevel { get; set; }
        public ICollection<StudentCourseSchedulesDto> StudentSchedules { get; set; }

    }
}
