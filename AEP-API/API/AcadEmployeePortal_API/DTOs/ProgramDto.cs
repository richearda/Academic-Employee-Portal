using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class ProgramDto
    {
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public ICollection<StudentDto> Students { get; set; }
    }
}
