using ISMS_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class CourseDto
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public int Units { get; set; }
        public int NoOfHours { get; set; }
        public string CourseTypeName { get; set; }
        public virtual CourseSchedulesDto Schedule { get; set; }
    }
}
