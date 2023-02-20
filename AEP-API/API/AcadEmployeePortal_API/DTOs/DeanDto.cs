using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class DeanDto
    {
        public int DeanID { get; set; }
        public PersonDto Person { get; set; }
        public CollegeDto College { get; set; }
        public bool IsActive { get; set; }
    }
}
